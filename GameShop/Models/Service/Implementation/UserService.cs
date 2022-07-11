using GameShop.Data;
using GameShop.Models.Entity;
using GameShop.Models.Exceptions;
using GameShop.Models.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Models.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly GameShopContext _context;

        public UserService(GameShopContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.MyUser.CountAsync();
        }

        public async Task<bool> Create(User user)
        {
            _context.MyUser.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        //Just erase data but not connections
        public async Task<bool> Delete(long id)
        {
            var user = await _context.MyUser.FindAsync(id);
            if(user == null)
            {
                return false;
            }
            user.Telno = "";
            user.Name = "";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserById(long id)
        {
            var user = await _context.MyUser.FindAsync(id);
            if (user == null)
            {
                throw new NotFoundException("Користувач не був знайдений");
            }
            return user;
        }

        public async Task<User> GetUserByIdentity(IdentityUser id)
        {
            var user = from b in _context.MyUser where b.Identity == id.Id select b;
            if (!user.Any())
            {
                throw new NotFoundException("Користувач не був знайдений");
            }
            return user.First();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.MyUser.ToListAsync();
        }

        public async Task<bool> Update(User user)
        {
            if (user == null)
            {
                return false;
            }
            _context.MyUser.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
