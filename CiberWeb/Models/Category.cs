using System.ComponentModel.DataAnnotations;

namespace CiberWeb.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
