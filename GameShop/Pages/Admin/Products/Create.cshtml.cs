#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GameShop.Models.Entity;
using GameShop.Models.Utils;
using GameShop.Models.Service.Interface;
using GameShop.Models.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace GameShop.Pages.Products
{
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ILogger<CreateModel> _logger;
        private readonly IProductTypeService _productTypeService;
        private readonly IFileService _fileService;


        public CreateModel(IProductService productService, IProductTypeService productTypeService, IFileService fileService)
        {
            _productService = productService;
            _productTypeService = productTypeService;
            _fileService = fileService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Types = await _productTypeService.GetAll();
            Product = new Product
            {
                WarhouseItem = new WarhouseItem()
            };
            return Page();
        }



        [BindProperty]
        public Product Product { get; set; }

        public IList<Product_Type> Types { get; private set; } = new List<Product_Type>();

        [BindProperty]
        public IFormFile Upload { get; init; }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Types = await _productTypeService.GetAll();
            ModelState.Remove("Product.URL");//ignore url field which is need as second id
            ModelState.Remove("Product.WarhouseItem.Product");//need to fix problem with mapped Product field in WarehouseItem
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Product.Url = Util.GetName(Product.ProductName);
            string fileName = Product.Url + '/' + Upload.FileName;
            await _fileService.Upload(FileType.IMAGE_GAME,fileName , Upload);
            Product.ProductImage = fileName;
            try
            {
                await _productService.Create(Product);
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError(e.Type, e.Message);
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
