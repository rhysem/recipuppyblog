using System.Data.Entity;

using RecipeAPI.Entities;

namespace RecipeAPI.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        //private readonly RecipeContext _context;
        //private readonly DbSet<Recipe> _recipes;

        //public RecipeRepository()
        //{
        //    _context = new RecipeContext();
        //}

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            var recipe = new Recipe { Id = 1, Name = "Tofu zucchini boats! Yum!", Ingredients = "tofu\nzucchini\nyumminess", Directions = "Enjoy!" };
            return new List<Recipe> { recipe };
        }

        public Task<Recipe> GetRecipeAsync(int id)
        {
            using (var db = new RecipeContext())
            {
                return (from r in db.Recipes
                        where r.Id == id
                        select r).FirstOrDefaultAsync();
            }
        }

        public Task<int> SaveRecipeAsync(Recipe recipe)
        {
            // validate - should this go in like a service?

            using (var db = new RecipeContext())
            {
                db.Recipes.Add(recipe);
                return db.SaveChangesAsync();
            }
        }

        public Task DeleteRecipeAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
