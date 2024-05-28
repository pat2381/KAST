using KAST.Application.Repositories;
using KAST.Infrastructure.Data;
using KAST.Infrastructure.Data.Repositories;
using KAST.Infrastructure.Interfaces;


namespace KAST.Infrastructure.Servcies
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
