using CiberWeb.Common;
using CiberWeb.ViewModel;
using CiberWeb.ViewModels;

namespace CiberWeb.Interface
{
    public interface IOrderServices
    {
        Task<OrderTableResult> GetAllOrder(DataTableParam param);
        Task<Result<bool>> CreateOrder(OrderRequest orderRequest);
        Task<IList<UserVM>> GetCustomer();
        Task<IList<ProductViewModel>> GetProducts();
        
    }
}
