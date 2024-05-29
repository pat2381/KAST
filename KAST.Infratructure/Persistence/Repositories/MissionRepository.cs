using KAST.Application.Repositories;

namespace KAST.Infrastructure.Data.Repositories
{
    public class MissionRepository : BaseRepository<Mission> , IMissionRepository
    {
        public MissionRepository(ApplicationDbContext context):base(context){}

        
    }
}
