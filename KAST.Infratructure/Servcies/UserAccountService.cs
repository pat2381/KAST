using KAST.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Infratructure.Servcies
{
    public class UserAccountService
    {
        private List<User> Users;


        public UserAccountService()
        {
            Users = new List<User>
            {
                new User{ UserId = new Guid(), Username = "admin" ,Password="admin", Role="Administrator"},
                new User{ UserId = new Guid(), Username = "user" ,Password="user", Role="User"},
            };
        }

        public User? GetByUserName(string userName)
        {
            return Users.FirstOrDefault(x => x.Username == userName);
        }
    }
}
