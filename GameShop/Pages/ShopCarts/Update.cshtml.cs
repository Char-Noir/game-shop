using GameShop.Models.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameShop.Pages.ShopCarts
{
    [IgnoreAntiforgeryToken]
    public class UpdateModel : PageModel
    {
        private readonly ILogger<UpdateModel> _logger;

        private readonly IProductService _productService;
        private readonly IShopCartService _shopCartService;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;

        public UpdateModel(UserManager<IdentityUser> userManager, IUserService userService, IShopCartService shopCartService, IProductService productService, ILogger<UpdateModel> logger)
        {
            _userManager = userManager;
            _userService = userService;
            _shopCartService = shopCartService;
            _productService = productService;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return NotFound();
        }
        public async Task<IActionResult> OnPost(int product, int quantity)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"�� ������� ����������� ����������� � ����� ID '{_userManager.GetUserId(User)}'.");
            }

            var productToAdd = await _productService.GetById(product);
            var myUser = await _userService.GetUserByIdentity(user);
            await _shopCartService.UpdateQuantity(productToAdd, myUser, quantity);
            return Redirect("./Index");
        }
    }
}