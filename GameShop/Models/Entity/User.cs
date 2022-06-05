using System;

namespace GameShop.Models.Entity
{
    //информация о пользователе
    public class User
    {
        public long Id { set; get; }
        public string Password { set; get; }
        //дату последнего логина в систему, как хочешь,оставляй или нет
        public DateTime LastLogin { set; get; }
        public string Username { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public DateTime DateJoined { set; get; }
        public string? Telno { set; get; }
        //один пользователь может иметь только одну роль в системе
        public UserStatus UserStatus { set; get; }

        public User(long id, string password, DateTime last_login, string username, string first_name, string last_name, string email, DateTime date_joined, UserStatus userStatus)
        {
            Id = id;
            Password = password;
            LastLogin = last_login;
            Username = username;
            FirstName = first_name;
            LastName = last_name;
            Email = email;
            DateJoined = date_joined;
            UserStatus = userStatus;
        }

        public User(long id, string password, DateTime last_login, string username, string first_name, string last_name, string email, DateTime date_joined, string? telno, UserStatus userStatus)
        {
            Id = id;
            Password = password;
            LastLogin = last_login;
            Username = username;
            FirstName = first_name;
            LastName = last_name;
            Email = email;
            DateJoined = date_joined;
            Telno = telno;
            UserStatus = userStatus;
        }

        public User()
        {
        }
    }
}