using KAST.Application.Repositories;
using KAST.Infratructure.Data;
using KAST.Infratructure.Data.Repositories;
using KAST.Infratructure.Interfaces;


namespace KAST.Infratructure.Servcies
{
    public class KastService : IKastService
    {
        private readonly ApplicationDbContext context;
        public KastService(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IRepositoryService RepositoryService => new RepositoryService(context);
    }
}
