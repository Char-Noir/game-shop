using GameShop.Models.Entity;
using GameShop.Models.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Pages.Admin.Users;

[Authorize(Roles = "admin")]
public class Details : PageModel
{
    private readonly IUserService _userService;
    private readonly UserManager<IdentityUser> _userManager;

    public Details(UserManager<IdentityUser> userManager, IUserService userService)
    {
        _userManager = userManager;
        _userService = userService;
    }
    
    public IdentityUser User { get; set; }
    public User MyUser { get; set; }
    public IList<string> Roles { get; set; }
    
    public async Task<IActionResult> OnGetAsync(long id)
    {
        MyUser = await _userService.GetUserById(id)??throw new InvalidOperationException("User not found"); 
        User = await _userManager.Users.FirstOrDefaultAsync(u=>u.Id == MyUser.Identity)??throw new InvalidOperationException("User not found");
        Roles = await _userManager.GetRolesAsync(User)??throw new InvalidOperationException("User not found");
        return Page();
    }
}