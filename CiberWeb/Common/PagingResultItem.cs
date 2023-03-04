namespace CiberWeb.Common
{
    public class PagingResultItem<T>:PagingResult
    {
        public List<T> Items { get; set; }
    }   
}
