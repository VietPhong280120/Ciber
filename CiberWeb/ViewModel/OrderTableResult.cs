namespace CiberWeb.ViewModel
{
    public class OrderTableResult
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public int Draw { get; set; }
        public IEnumerable<OrderVM> Data { get; set; }
    }
}   
