using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culinu.Backend.Models
{
    public class RecipeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;
        public string? Name { get; set; } = default!;
        public IngredientModel[]? Ingredients { get; set; } = default!;
    }
}