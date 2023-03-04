using System.ComponentModel.DataAnnotations;

namespace CiberWeb.ViewModel
{
    public class OrderRequest
    {
        public int Id { get; set; }
        [Required]
        public string? OrderName { get; set; }
        [Required]
        public IEnumerable<int> ProductID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
