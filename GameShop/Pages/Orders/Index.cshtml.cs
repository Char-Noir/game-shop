using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameShop.Data;
using GameShop.Models.Entity;
using GameShop.Models.Service.Interface;
using Microsoft.AspNetCore.Identity;

namespace GameShop.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly GameShop.Data.GameShopContext _context;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(GameShop.Data.GameShopContext context, IOrderService orderService, UserManager<IdentityUser> userManager, IUserService userService)
        {
            _context = context;
            _orderService = orderService;
            _userManager = userManager;
            _userService = userService;
        }

        public IList<Models.Entity.Orders> Orders { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.Orders != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Не вдалося завантажити користувача з таким ID '{_userManager.GetUserId(User)}'.");
                }
                var myUser = await _userService.GetUserByIdentity(user);
                Orders = await _orderService.GetOrders(myUser.Id);
                return Page();
            }
            return NotFound();
        }
    }
}
