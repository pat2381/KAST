using KAST.Application.Repositories;
using KAST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Infratructure.Data.Repositories
{
    public class ModsRepository : BaseRepository<Mod>, IModsRepository
    {
        public ModsRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
