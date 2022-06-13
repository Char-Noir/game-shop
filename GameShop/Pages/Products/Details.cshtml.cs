#nullable disable
using GameShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameShop.Models.Entity;
using GameShop.Models.Utils;

namespace GameShop.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly GameShopContext _context;

        public DetailsModel(GameShopContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.Include(m=>m.ProductTypes).ThenInclude(x=>x.Product_Type).FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            Product.InitProductWithCategories();
            Product.InitPackageList();
            return Page();
        }
    }
}
