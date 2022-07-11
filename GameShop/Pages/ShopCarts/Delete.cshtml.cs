using GameShop.Models.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameShop.Pages.ShopCarts
{
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class DeleteModel : PageModel
    {
        
        private readonly ILogger<DeleteModel> _logger;

        private readonly IProductService _productService;
        private readonly IShopCartService _shopCartService;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteModel(UserManager<IdentityUser> userManager, IUserService userService, IShopCartService shopCartService, IProductService productService, ILogger<DeleteModel> logger)
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
        public async Task<IActionResult> OnPost(int product)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"�� ������� ����������� ����������� � ����� ID '{_userManager.GetUserId(User)}'.");
            }

            var productToAdd = await _productService.GetById(product);
            var myUser = await _userService.GetUserByIdentity(user);
            await _shopCartService.RemoveFromCart(productToAdd, myUser);
            return Redirect("./Index");
        }
    }
}
