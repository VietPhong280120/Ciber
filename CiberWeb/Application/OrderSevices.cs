using CiberWeb.Common;
using CiberWeb.Data;
using CiberWeb.Interface;
using CiberWeb.Models;
using CiberWeb.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CiberWeb.ViewModels;
using System.Net.WebSockets;

namespace CiberWeb.Application
{
    public class OrderSevices : IOrderServices
    {
        private CiberDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppUserRole> _roleManage;
        public OrderSevices(CiberDbContext context, RoleManager<AppUserRole> roleManage, UserManager<AppUser> userManager)
        {
            _context = context;
            _roleManage = roleManage;
            _userManager = userManager;
        }

        public async Task<Result<bool>> CreateOrder(OrderRequest orderRequest)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            var customer = await _userManager.FindByIdAsync(orderRequest.UserID);
            foreach (var productId in orderRequest.ProductID)
            {
                var quantity = _context.Products.Where(x => x.ID == productId).Select(s => s.Quantity).FirstOrDefault();
                if (quantity < orderRequest.Amount)
                {
                    return new ErrorResult<bool>("Number of product also not enough");
                }
                orderDetails.Add(new OrderDetail { ProductId = productId, OrderId = orderRequest.Id });
            }
            var order = new Order()
            {
                User = customer,
                Name = orderRequest.OrderName,
                Quantity = orderRequest.Amount,
                OrderDate = orderRequest.OrderDate,
                OrderDetails = orderDetails

            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return new SuccessResult<bool>();
        }

        public async Task<OrderTableResult> GetAllOrder(DataTableParam param)
        {
            var query = from ord in _context.OrderDetails
                        join or in _context.Orders on ord.OrderId equals or.ID
                        join pr in _context.Products on ord.ProductId equals pr.ID
                        select new { ord, or, pr };
            //if (!string.IsNullOrEmpty(seachstring))
            //{
            //    query = query.Where(x => x.or.Name.Contains(seachstring) || x.pr.Name.Contains(seachstring));
            //}
            

            var totalRow = await query.CountAsync();
                       
            OrderTableResult orders = new OrderTableResult();
            orders.Draw = param.Draw;
            orders.RecordsTotal = totalRow;
            orders.RecordsFiltered = orders.RecordsTotal;
            var searchString = param.Search.Value;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.or.Name.Contains(searchString) || x.pr.Name.Contains(searchString));
            }
            var sort = param.Order.FirstOrDefault();
            if (sort!=null)
            {
                if (sort.Dir == "asc")
                {
                    switch (sort.Column)
                    {
                        case 0: 
                            query = query.OrderBy(x=>x.pr.Name); break;
                    }
                }
                else
                {
                    switch (sort.Column)
                    {
                        case 0:
                            query = query.OrderByDescending(x => x.pr.Name); break;
                    }
                }

            }
            orders.Data =  await query.Skip(param.Start)
                          .Take(param.Length)
                           .Select(x => new OrderVM()
                           {
                               Id = x.ord.Id,
                               OrderName = x.or.Name,
                               ProductName = x.pr.Name,
                               CategoryName = _context.Categories.Where(c => c.ID == x.pr.CategoryId).Select(x => x.Name).FirstOrDefault(),
                               CustomerName = x.or.User.UserName,
                               OrderDate = x.or.OrderDate.ToString("dd/MM/yyyy"),
                               Amount = x.or.Quantity,

                           }).ToListAsync();
            return orders;
        }

        public async Task<IList<UserVM>> GetCustomer()
        {
            var result = new List<UserVM>();
            var roles = _roleManage.Roles;
            var admin = await _userManager.GetUsersInRoleAsync("admin");
            var adminID = await _userManager.GetUserIdAsync(admin.FirstOrDefault());
            var customers = _userManager.Users.Where(x => x.Id.ToString() != adminID).ToList();
            foreach (var customer in customers)
            {
                var vaule = new UserVM()
                {
                    ID = customer.Id.ToString(),
                    UserName = customer.UserName
                };
                result.Add(vaule);
            }
            return result;
        }

        public async Task<IList<ProductViewModel>> GetProducts()
        {
            var result =await _context.Products.Select(s => new ProductViewModel()
            {
                Id = s.ID,
                Text = s.Name
            }).ToListAsync();
            return result;
        }
    }
}
