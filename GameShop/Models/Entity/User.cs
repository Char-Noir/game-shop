using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameShop.Models.Entity
{
    //информация о пользователе
    public class User
    {
        public long Id { set; get; }
        public string Identity { get; set; }
        public string Name { set; get; }
        public string? Telno { set; get; }
        
        public DateTime? BirthDay { set; get; }
        
        [NotMapped]
        public int Age { set; get; }

        public User(long id, string firstName, IdentityUser identity)
        {
            Id = id;
            Name = firstName;
            Identity = identity.Id;
        }

    

        public User()
        {
        }
    }
}