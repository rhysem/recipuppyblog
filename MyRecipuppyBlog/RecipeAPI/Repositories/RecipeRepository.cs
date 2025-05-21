using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

using RecipeAPI.Entities;

namespace RecipeAPI.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AmazonDynamoDBClient _client;
        private readonly IConfiguration _config;
        const string TableName = "Recipes";

        private List<Recipe> _fakeRecipes;

        public RecipeRepository(IConfiguration config)
        {
            _config = config;

            var accessKey = _config.GetValue<string>("AWS:AccessKey");
            var secretKey = _config.GetValue<string>("AWS:SecretKey");
            var region = Amazon.RegionEndpoint.GetBySystemName(_config.GetValue<string>("AWS:Region"));
            _client = new AmazonDynamoDBClient(accessKey, secretKey, region);
        }


        public async Task<IEnumerable<Recipe>> GetRecipes(bool testMode)
        {
            var recipeList = new List<Recipe>();

            if (testMode)
            {
                SetFakeRecipes();
                recipeList = _fakeRecipes;
            }

            else
            {
                var request = new ScanRequest()
                {
                    TableName = "Recipes",
                };

                var resp = await _client.ScanAsync(request);

                if (resp.HttpStatusCode != System.Net.HttpStatusCode.OK) // what other httpcodes should be allowed?
                {
                    // log err
                    return new List<Recipe>() { new Recipe() }; // return err message?
                }

                foreach (var item in resp.Items)
                {
                    recipeList.Add(MapToRecipe(item));
                }
            }


            return recipeList;
        }

        public async Task<Recipe> GetRecipeAsync(string id)
        {
            var request = new GetItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue>() { { "RecipeID", new AttributeValue { S = id } } }
            };

            var resp = await _client.GetItemAsync(request);
            return MapToRecipe(resp.Item);
        }

        public async Task<string> SaveRecipeAsync(Recipe recipe)
        {
            var recipeId = Guid.NewGuid().ToString();
            var recipeItem = new Dictionary<string, AttributeValue>
            {
                ["RecipeID"] = new AttributeValue { S = recipeId },
                ["Name"] = new AttributeValue { S = recipe.Name },
                ["Description"] = new AttributeValue { S = recipe.Description },
                ["Directions"] = new AttributeValue { S = recipe.Directions },
                ["Ingredients"] = new AttributeValue { S = recipe.Ingredients }
            };

            var request = new PutItemRequest
            {
                TableName = TableName,
                Item = recipeItem
            };

            var resp = await _client.PutItemAsync(request);
            // TO DO: check HTTPStatusCode
            return recipeId;
        }

        public Task DeleteRecipeAsync(int id)
        {
            throw new NotImplementedException();
        }

        private Recipe MapToRecipe(Dictionary<string, AttributeValue> item)
        {
            return new Recipe()
            {
                Id = item["RecipeID"]?.S ?? "",
                Name = item["Name"]?.S ?? "",
                Description = item["Description"]?.S ?? "",
                Ingredients = item["Ingredients"]?.S ?? "",
                Directions = item["Directions"]?.S ?? ""
            };
        }

        private void SetFakeRecipes()
        {
            if (_fakeRecipes == null || _fakeRecipes.Count == 0)
            {
                _fakeRecipes = new List<Recipe>
                {
                    new Recipe { Id = "1", Name = "Apple", Description = "Just an apple", Ingredients = "Apple", Directions = "eat apple" },
                    new Recipe { Id = "2", Name = "Toast", Ingredients = "bread\npeanut butter", Directions = "toast bread\ntop with peanut butter\nenjoy!" },
                    new Recipe { Id = "3", Name = "Yogurt Bowl", Description = "my favorite breakfasttime treat", Ingredients = "vanilla yogurt\ngranola\n1 banana\npb fit", Directions = "Combine vanilla yogurt and some pb fit in a bowl. Top with banana slices and granola. Drizzle with pb fit mixed with water. Eat!" }
                };
            }
        }
    }
}
