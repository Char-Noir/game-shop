#nullable disable
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

namespace GameShop.Pages.Products
{
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        private readonly GameShop.Data.GameShopContext _context;

        public DeleteModel(GameShop.Data.GameShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.Include(p=>p.WarhouseItem).FirstOrDefaultAsync(p=>p.Id==id);

            if (Product != null)
            {
                Product.WarhouseItem.ProductAmount = 0;
                _context.Product.Update(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
