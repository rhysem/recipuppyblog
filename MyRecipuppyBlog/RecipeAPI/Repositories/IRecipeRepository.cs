using RecipeAPI.Entities;

namespace RecipeAPI.Repositories
{
    public interface IRecipeRepository
    {
        public Task<IEnumerable<Recipe>> GetRecipes();
        public Task<Recipe> GetRecipeAsync(int id);
        public Task<int> SaveRecipeAsync(Recipe recipe);
        public Task DeleteRecipeAsync(int id);
        //public List<Recipe> GetRecipesByCategory(Category category);
    }
}
