namespace Culinu.Backend.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngredientModel>? Ingredients { get; set; }
    }
}