using GameShop.Models.Entity;
using GameShop.Models.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Pages.Admin.Users
{
    [Authorize(Roles = "admin")]
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService, UserManager<IdentityUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        private readonly UserManager<IdentityUser> _userManager;

        private IList<IdentityUser> Users { get; set; } 
        private IList<User> MyUsers { get; set; }
        public IList<ComplexUser> ComplexUsers { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();
            MyUsers = await _userService.GetUsers();
            ComplexUsers = new List<ComplexUser>();
            foreach(var user in MyUsers)
            {
                var innUs = Users.FirstOrDefault(u => u.Id == user.Identity)?? throw new Exception("Users are not comparable");;
                IList<string> roles = await _userManager.GetRolesAsync(innUs);
               
                ComplexUsers.Add(new ComplexUser (innUs,user, roles));
               
            }

            return Page();
        }
        public record ComplexUser(IdentityUser IdentityUser,User User,IList<string> Roles);
    }
}
