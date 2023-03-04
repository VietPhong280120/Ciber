using CiberWeb.Data;
using CiberWeb.Interface;
using CiberWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using CiberWeb.ViewModels;

namespace CiberWeb.Controllers
{
    public class OrderController : Controller
    {
        private IOrderServices _services;
        private CiberDbContext _dbContext;
        public OrderController(IOrderServices services,CiberDbContext context)
        {
            _services = services;
            _dbContext= context;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult>GetOrderList(DataTableParam param)
        {
            var result = await _services.GetAllOrder(param);
            return Json(result);
        }
        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequest orderRequest)
        {
            var result = await _services.CreateOrder(orderRequest);
            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var data = await _services.GetCustomer();
            return Json(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var result = await _services.GetProducts();
            return Json(result);
        }
    }
}
