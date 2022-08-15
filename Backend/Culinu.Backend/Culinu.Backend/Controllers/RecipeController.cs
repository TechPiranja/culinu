using Culinu.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Culinu.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly CulinuContext _culinuContext;

        public RecipeController(CulinuContext culinuContext
            , ILogger<RecipeController> logger)
        {
            _logger = logger;
            _culinuContext = culinuContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeModel>>> Get([FromBody] string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return BadRequest();
            }
            var recipes = _culinuContext.Recipes?
                .Where(x => x.Name.ToLower().Contains(Name.ToLower()))
                .ToList();
            await _culinuContext.SaveChangesAsync();

            if (recipes != null)
                return Ok(recipes);

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<RecipeModel>> Post([FromBody] RecipeModel recipe)
        {
            if (string.IsNullOrEmpty(recipe.Name) || recipe.Ingredients == null)
                return BadRequest();

            await _culinuContext.AddAsync(recipe);
            await _culinuContext.SaveChangesAsync();

            return Ok(recipe);
        }
    }
}