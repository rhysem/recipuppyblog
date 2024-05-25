using RecipeAPI.Entities;

namespace RecipeAPI.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            var recipe = new Recipe { Id = 1, Name = "Tofu zucchini boats! Yum!", Ingredients = new List<string> { "tofu", "zucchini", "yumminess" }, SingleStepRecipeText = "Enjoy!" };
            return new List<Recipe> { recipe };
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> SaveRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRecipe(int id)
        {
            throw new NotImplementedException();
        }
    }
}
