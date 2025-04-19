using Microsoft.AspNetCore.Mvc;

using RecipeAPI.Entities;
using RecipeAPI.Repositories;

namespace RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/recipes")] // api/[controller] or api/recipes
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipesController()
        {
            // TODO - dependency injection!!!
            _recipeRepository = new RecipeRepository();
        }

        [HttpGet]
        [Route("")]
        [Route("Recipes")]
        public Task<IEnumerable<Recipe>> GetRecipes()
        {
            return _recipeRepository.GetRecipes();
        }

        // TODO - handle CSRF - in whole app!!!
        [HttpPost]
        [Route("")]
        public async Task<int> CreateRecipe(Recipe recipe)
        {
            //recipe.Id = id;
            try
            {
                // this works-ish but throws on SaveChangesAsync - why? 
                // is this even relevant? do I want to switch to DynamoDB now?
                return await _recipeRepository.SaveRecipeAsync(recipe);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return -1;
            }
        }

        //[HttpPost]
        //public async Task<Recipe> SaveRecipe(int? id, Recipe recipe)
        //{
        //    if (id == null)
        //    {

        //    }

        //    // handle updates later
        //}
    }
}
