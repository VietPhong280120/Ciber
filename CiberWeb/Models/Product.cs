using System.ComponentModel.DataAnnotations;

namespace CiberWeb.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<OrderDetail>? OrderDetails { get; set; }
        public Category? Category { get; set; }
    }
}
