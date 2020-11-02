using System.ComponentModel.DataAnnotations;

namespace DynamicListTest.Models
{
    public class RecipeItem
    {
        [Key]
        public int Id { get; set; }
        public string Ingredient { get; set; }
    }
}
