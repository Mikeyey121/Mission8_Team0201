using System.ComponentModel.DataAnnotations;

namespace CategoryModel.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }    
    }
}
