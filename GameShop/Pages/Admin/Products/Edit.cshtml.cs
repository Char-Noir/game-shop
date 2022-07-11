#nullable disable
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

namespace GameShop.Pages.Products
{
    [Authorize(Roles = "admin")]
    public class EditModel : PageModel
    {
        private readonly GameShop.Data.GameShopContext _context;
        private readonly ILogger<EditModel> _logger;

        public EditModel(GameShop.Data.GameShopContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.Include(p=>p.WarhouseItem).FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Product.WarhouseItem.Product");
            ModelState.Remove("Product._productTypes");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var product = await _context.Product.Include(p => p.WarhouseItem).Include(p => p.ProductTypes).ThenInclude(t => t.Product_Type).FirstOrDefaultAsync();
            product.ProductName = Product.ProductName;
            product.ProductPrice = Product.ProductPrice;
            product.ProductDescription = Product.ProductDescription;
            product.GameDuration = Product.GameDuration;
            product.WarhouseItem.ProductAmount = Product.WarhouseItem.ProductAmount;
            product.Age = Product.Age;
            product.NumOfPlayers = Product.NumOfPlayers;
            product.Localisation = Product.Localisation;
            product.PackageList = Product.PackageList;
            product.ProductImage = Product.ProductImage;
            product.Chars = Product.Chars;
            _logger.Log((LogLevel.Information), $"Product updated:{product.ProductImage}");
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
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

        private bool ProductExists(long id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
