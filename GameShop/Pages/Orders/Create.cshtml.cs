using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameShop.Data;
using GameShop.Models.Entity;
using GameShop.Models.Service.Implementation;
using GameShop.Models.Service.Interface;
using Microsoft.AspNetCore.Identity;

namespace GameShop.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly GameShop.Data.GameShopContext _context;
        private readonly IShopCartService _shopCartService;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOrderService _orderService; 

        public CreateModel(GameShop.Data.GameShopContext context, IShopCartService shopCartService, UserManager<IdentityUser> userManager, IUserService userService, IOrderService orderService)
        {
            _context = context;
            _shopCartService = shopCartService;
            _userManager = userManager;
            _userService = userService;
            _orderService = orderService;
        }

        public ShopCart ShopCart { get; set; }
        
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Не вдалося завантажити користувача з таким ID '{_userManager.GetUserId(User)}'.");
            }
            var myUser = await _userService.GetUserByIdentity(user);
            ShopCart = await _shopCartService.GetShopCartByUser(myUser);
            return Page();
        }

        [BindProperty]
        public Models.Entity.Orders Orders { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Orders.OrderDate");
            ModelState.Remove("Orders.Customer");
            ModelState.Remove("Orders.OrderDetails");
            ModelState.Remove("Orders.OrderStatus");
            if (!ModelState.IsValid || _context.Orders == null || Orders == null)
            {
                var user1 = await _userManager.GetUserAsync(User);
                if (user1 == null)
                {
                    return NotFound($"Не вдалося завантажити користувача з таким ID '{_userManager.GetUserId(User)}'.");
                }
                var myUser1 = await _userService.GetUserByIdentity(user1);
                ShopCart = await _shopCartService.GetShopCartByUser(myUser1);
                return Page();
            }
            Orders.OrderDate = DateTime.Now;
            Orders.Customer = await _userService.GetUserByIdentity(_userManager.GetUserAsync(User).Result);
            Orders.OrderStatus = OrderStatus.CREATED;
            
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Не вдалося завантажити користувача з таким ID '{_userManager.GetUserId(User)}'.");
            }
            var myUser = await _userService.GetUserByIdentity(user);
            ShopCart = await _shopCartService.GetShopCartByUser(myUser);
            
            Orders.OrderDetails = new List<OrderDetail>();
            
            foreach (var item in ShopCart.ListShopItems)
            {
                Orders.OrderDetails.Add(new OrderDetail()
                {
                    Product = item.Product,
                    Quantity = item.PAmount,
                    Price = item.Product.ProductPrice*item.PAmount
                });
            }
            
            await _orderService.CreateOrder(Orders);
            await _shopCartService.ClearCart(myUser);
            return RedirectToPage("./Index");
        }
    }
}
