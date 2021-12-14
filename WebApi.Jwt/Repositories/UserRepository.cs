using System.Collections.Generic;
using System.Linq;
using WebApi.Jwt.Models;

namespace WebApi.Jwt.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "Suporte",
                    Password = "123456",
                    Role = "Admin"
                },
                new User
                {
                    Id = 2,
                    Username = "Usuario",
                    Password = "123456",
                    Role = "Basico"
                }
            };
            return users
                .Where(x => x.Username
                .ToLower() == username
                .ToLower() && x.Password == password)
                .FirstOrDefault();
        }
    }
}
