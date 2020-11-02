using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DynamicListTest.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RecipeItem> Items { get; set; }

        public Recipe()
        {
            Items = new List<RecipeItem>();
        }
    }
}
