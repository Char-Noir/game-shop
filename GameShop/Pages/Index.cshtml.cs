using GameShop.Models.Entity;
using GameShop.Models.Entity.RequestEntity;
using GameShop.Models.Service.Interface;
using GameShop.Models.Utils.Pagination;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserService _userService;

        public IndexModel(ILogger<IndexModel> logger, IProductService productService, UserManager<IdentityUser> userManager, IUserService userService)
        {
            _logger = logger;
            _productService = productService;
            _userManager = userManager;
            _userService = userService;
            News = new List<Product>();
        }
        
        public IList<Product> News { get; set; } 
        public IList<Product> ByAge { get; set; } 
        
        public async Task<IActionResult> OnGet()
        {
            _logger.Log(LogLevel.Information, "Index OnGet started!");
            News = await _productService.GetNewProducts(4);
            IdentityUser user;
            User? myuser;
            user = await _userManager.GetUserAsync(User);
            try
            {
                myuser = await _userService.GetUserByIdentity(user);

            }
            catch(Exception e)
            {
                myuser = null;
            }
            
           
            ByAge = await _productService.GetByUserAge(myuser,4);
            _logger.Log(LogLevel.Information,"Index OnGet successfully ended!");   
            return Page();
        }
    }
}