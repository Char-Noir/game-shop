using GameShop.Models.Entity;
using GameShop.Models.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameShop.Pages;

public class Catalog : PageModel
{
    private readonly ILogger<Catalog> _logger;
    private readonly IProductTypeService _productTypeService;

    public Catalog(ILogger<Catalog> logger, IProductTypeService productTypeService)
    {
        _logger = logger;
        _productTypeService = productTypeService;
    }
    
    public IList<Product_Type> Categories { get; set; }
    
    public async Task<IActionResult> OnGet()
    {
        _logger.Log(LogLevel.Information,"Catalog OnGet started!");
        Categories = await _productTypeService.GetAll();
        _logger.Log(LogLevel.Information,"Catalog OnGet successfully ended!");
        return Page();
    }
}