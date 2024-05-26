using KAST.Domain.Entities;
using KAST.Infratructure.Data;
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
        
        private readonly ApplicationDbContext context;

        public UserAccountService(ApplicationDbContext dbContext) => context = dbContext;
       

        public User GetByUserName(string userName)
        {
            return context.Users.FirstOrDefault(u => u.Username == userName);
        }



    }
}
