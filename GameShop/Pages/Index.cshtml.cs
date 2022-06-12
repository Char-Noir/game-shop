using GameShop.Models.Entity;
using GameShop.Models.Entity.RequestEntity;
using GameShop.Models.Service.Interface;
using GameShop.Models.Utils.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;

        public IndexModel(ILogger<IndexModel> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        
        public IList<Product> Product { get; set; } 
        
        public async Task<IActionResult> OnGet()
        {
            var all = await _productService.GetAll();
            Product =  all.Take(4).ToList();
            
            return Page();
        }
    }
}