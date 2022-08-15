using Microsoft.AspNetCore.Mvc;

namespace Culinu.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(ILogger<RecipeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRecipe")]
        public int Get()
        {
            return 1;
        }
    }
}