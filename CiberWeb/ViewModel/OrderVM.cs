using NuGet.Protocol.Core.Types;

namespace CiberWeb.ViewModel
{
    public class OrderVM
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public int Amount { get; set; }
    }
}
