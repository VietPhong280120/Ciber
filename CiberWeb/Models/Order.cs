using System.ComponentModel.DataAnnotations;

namespace CiberWeb.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public AppUser? User { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderDetail>? OrderDetails { get; set; }
    }
}
