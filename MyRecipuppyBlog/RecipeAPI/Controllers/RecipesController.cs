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

        public RecipesController(IRecipeRepository recipeRepository)
        {
            // TODO - dependency injection!!!
            // hmmm - LOOKS like this sets up repo/dependencies ok, but AddRecipe.jsx gets a 400 back - never gets to endpoint in CreateRecipe - what's going on?
            _recipeRepository = recipeRepository;
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
        public async Task<string> CreateRecipe(Recipe recipe)
        {
            try
            {
                return await _recipeRepository.SaveRecipeAsync(recipe);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return "-1";
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
