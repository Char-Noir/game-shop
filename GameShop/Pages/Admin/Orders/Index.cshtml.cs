using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameShop.Data;
using GameShop.Models.Entity;
using Microsoft.AspNetCore.Authorization;

namespace GameShop.Pages.Admin.Orders
{
    [Authorize(Roles = "admin,manager")]
    public class IndexModel : PageModel
    {
        private readonly GameShop.Data.GameShopContext _context;

        public IndexModel(GameShop.Data.GameShopContext context)
        {
            _context = context;
        }

        public IList<GameShop.Models.Entity.Orders> Orders { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Orders = await _context.Orders.ToListAsync();
            }
        }
    }
}
