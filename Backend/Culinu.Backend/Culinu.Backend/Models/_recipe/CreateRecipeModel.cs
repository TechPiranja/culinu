using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culinu.Backend.Models
{
    public class CreateRecipeModel
    {
        public string? Name { get; set; } = default!;
        public IngredientModel Ingredients { get; set; } = default!;
    }
}