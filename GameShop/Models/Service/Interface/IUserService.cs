using GameShop.Models.Entity;
using Microsoft.AspNetCore.Identity;

namespace GameShop.Models.Service.Interface
{
    public interface IUserService
    {
        public Task<User> GetUserById(long id);
        public Task<User> GetUserByIdentity(IdentityUser id);
        public Task<List<User>> GetUsers();
        public Task<bool> Create(User user);
        public Task<bool> Update(User user);
        public Task<bool> Delete(long id);
    }
}
