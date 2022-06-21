using GameShop.Models.Entity;
using GameShop.Models.Entity.RequestEntity;
using GameShop.Models.Exceptions;
using GameShop.Models.Service.Interface;
using GameShop.Models.Utils.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameShop.Pages.Products;

public class Index : PaginationModel
{
    private readonly IProductService _productService;
    private readonly IProductTypeService _productTypeService;
    private readonly ILogger<Index> _logger;

    public Index(IProductService productService, IProductTypeService productTypeService, ILogger<Index> logger)
    {
        _productService = productService;
        _productTypeService = productTypeService;
        _logger = logger;
    }
    public IList<Product> Product { get; private set; }
    public (double,double) Prices { get; private set; }
    private IList<Product_Type> Categories { get; set; }

    public ProductsFilterEntity FilterEntity { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        _logger.Log(LogLevel.Information,"Products index OnGet started!");
        Categories = await _productTypeService.GetAll();
        FilterEntity = new ProductsFilterEntity(Categories, Request.Query);
        var paginationDataTable = new PaginationDataTable(OrderBy) { CurrentPage = CurrentPage, PageSize=PageSize};
        try
        {
            var response = await _productService.GetPaginatedResult(paginationDataTable, FilterEntity);
            Product = response.Result;
            Count = response.Count;
            Prices = response.Prices;
        }
        catch(NotFoundException)
        {
            _logger.Log(LogLevel.Error,"Products index OnGet ended with notfound error!");
            return NotFound();
        }
        catch (Exception)
        {
            _logger.Log(LogLevel.Error,"Products index OnGet ended with unknown error!");
            return StatusCode(500);
        }
        _logger.Log(LogLevel.Information,"Products index OnGet successfully ended!");
        return Page();
    }
}