using GameShop.Models.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameShop.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public DashboardModel(IUserService userService, IOrderService orderService, IProductService productService)
        {
            _userService = userService;
            _orderService = orderService;
            _productService = productService;
        }

        public long Orders { get; set; }
        public double OrderPercentage { get; set; }
        public long Customers { get; set; }
        public long Products { get; set; }
        public double ProductPercentage { get; set; }
        public int Warehouse { get; set; }
        public double WarehousePercentage { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {

            Orders = (await _orderService.GetOrders()).Count;
            var orders = await _orderService.GetFrom(DateTime.Today.AddMonths(-1));
            var count = 0;
            foreach (var order in orders)
            {
                if (order.OrderStatus == Models.Entity.OrderStatus.DELIVERED)
                {
                    count++;
                }
            }
            OrderPercentage = (double)count / orders.Count;

            Customers = await _userService.Count();

            Products = await _productService.Count();

            var products = await _productService.GetAll();

            count = 0;

            foreach(var item in products)
            {
                if (item.WarhouseItem.ProductAmount > 0)
                {
                    count++;
                }
            }

            ProductPercentage = (double)count / Products;

            Warehouse = count;

            count = 0;

            foreach (var item in products)
            {
                if (item.WarhouseItem.ProductAmount > 100)
                {
                    count++;
                }
            }

            return Page();
        }
    }
}
