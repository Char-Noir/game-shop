using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameShop.Data;
using GameShop.Models.Entity;
using Microsoft.AspNetCore.Authorization;

namespace GameShop.Pages.Admin.Orders
{
    [Authorize(Roles = "admin,manager")]
    public class EditModel : PageModel
    {
        private readonly GameShop.Data.GameShopContext _context;

        public EditModel(GameShop.Data.GameShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderStatus OrderStatus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long id)
        {
            if ( _context.Orders == null)
            {
                return NotFound();
            }

            var orders =  await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }
            OrderStatus = orders.OrderStatus;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var orders = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }
            orders.OrderStatus = OrderStatus;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrdersExists(long id)
        {
          return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
