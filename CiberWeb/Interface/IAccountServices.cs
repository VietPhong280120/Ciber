using CiberWeb.Common;
using CiberWeb.ViewModel;

namespace CiberWeb.Interface
{
    public interface IAccountServices
    {
        Task<Result<string>> Login(LoginRequest loginViewModel);
        Task<Result<bool>>Register(RegisterRequest registerViewModel);
        Task<UserVM> GetAllUser();
    }
}
