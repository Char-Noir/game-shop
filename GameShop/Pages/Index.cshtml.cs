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
            News = new List<Product>();
        }
        
        public IList<Product> News { get; set; } 
        public IList<Product> Popular { get; set; } 
        
        public async Task<IActionResult> OnGet()
        {
            _logger.Log(LogLevel.Information, "Index OnGet started!");
            News = await _productService.GetNewProducts(4);
            Popular = await _productService.GetPopularProducts(4);
            _logger.Log(LogLevel.Information,"Index OnGet successfully ended!");   
            return Page();
        }
    }
}