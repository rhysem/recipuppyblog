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

        public RecipeRepository(IConfiguration config)
        {
            _config = config;

            var accessKey = _config.GetValue<string>("AWS:AccessKey");
            var secretKey = _config.GetValue<string>("AWS:SecretKey");
            var region = Amazon.RegionEndpoint.GetBySystemName(_config.GetValue<string>("AWS:Region"));
            _client = new AmazonDynamoDBClient(accessKey, secretKey, region);
        }


        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> GetRecipeAsync(string id)
        {
            var request = new GetItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue>() { { "RecipeID", new AttributeValue { S = id } } }
            };

            var resp = await _client.GetItemAsync(request);
            var attributeMap = resp.Item; // map to recipe

            return new Recipe()
            {

            };
        }

        public async Task<string> SaveRecipeAsync(Recipe recipe)
        {
            // validate - should this go in like a service?

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
            // TO DO: look at HTTPStatusCode or whatever it's called
            return recipeId;
        }

        public Task DeleteRecipeAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
