using RecipeAPI.Entities;

namespace RecipeAPI.Repositories
{
    public interface IRecipeRepository
    {
        public Task<IEnumerable<Recipe>> GetRecipes();
        public Task<Recipe> GetRecipe(int id);
        public Task<Recipe> SaveRecipe(Recipe recipe);
        public Task DeleteRecipe(int id);
        //public List<Recipe> GetRecipesByCategory(Category category);
    }
}
