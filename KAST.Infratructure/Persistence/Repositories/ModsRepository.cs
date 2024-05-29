using KAST.Application.Repositories;


namespace KAST.Infrastructure.Data.Repositories
{
    public class ModsRepository : BaseRepository<Mod>, IModsRepository
    {
        public ModsRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
