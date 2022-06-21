using Microsoft.AspNetCore.Identity;
using System;

namespace GameShop.Models.Entity
{
    //информация о пользователе
    public class User
    {
        public long Id { set; get; }
        public string Identity { get; set; }
        public string Name { set; get; }
        public string? Telno { set; get; }

        public User(long id, string first_name, IdentityUser identity)
        {
            Id = id;
            Name = first_name;
            Identity = identity.Id;
        }

    

        public User()
        {
        }
    }
}