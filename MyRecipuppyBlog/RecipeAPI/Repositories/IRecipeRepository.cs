using RecipeAPI.Entities;

namespace RecipeAPI.Repositories
{
    public interface IRecipeRepository
    {
        public Task<IEnumerable<Recipe>> GetRecipes();
        public Task<Recipe> GetRecipeAsync(string id);
        public Task<string> SaveRecipeAsync(Recipe recipe);
        public Task DeleteRecipeAsync(int id);
        //public List<Recipe> GetRecipesByCategory(Category category);
    }
}
