#nullable disable
using System.Collections;
using GameShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameShop.Models.Entity;
using GameShop.Models.Service.Interface;
using GameShop.Models.Utils;

namespace GameShop.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;

        public DetailsModel(IProductService productService)
        {
            _productService = productService;
        }

        public Product Product { get; set; }
        public IList<Product> BoughtWith { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productService.GetById(id);
            BoughtWith = await _productService.GetBoughtWith(id,4);
            
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
