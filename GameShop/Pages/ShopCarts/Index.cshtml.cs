using GameShop.Models.Entity;
using GameShop.Models.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameShop.Pages.ShopCarts;

[Authorize]
[IgnoreAntiforgeryToken]
public class Index : PageModel
{
    private readonly ILogger<AddModel> _logger;
    
    private readonly IProductService _productService;
    private readonly IShopCartService _shopCartService;
    private readonly IUserService _userService;
    private readonly UserManager<IdentityUser> _userManager;

    public Index(ILogger<AddModel> logger, IProductService productService, IShopCartService shopCartService, IUserService userService, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _productService = productService;
        _shopCartService = shopCartService;
        _userService = userService;
        _userManager = userManager;
    }

    public ShopCart ShopCart { get; set; }
    
    public async Task<IActionResult> OnGet()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Не вдалося завантажити користувача з таким ID '{_userManager.GetUserId(User)}'.");
        }
        var myUser = await _userService.GetUserByIdentity(user);
        ShopCart = await _shopCartService.GetShopCartByUser(myUser);
        return Page();
    }
}