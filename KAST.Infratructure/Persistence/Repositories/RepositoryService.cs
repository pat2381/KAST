using KAST.Application.Repositories;


namespace KAST.Infrastructure.Data.Repositories
{
    public class RepositoryService : IRepositoryService
    {
        private readonly Lazy<IMissionRepository> _lazyMissionRepository;
        private readonly Lazy<IModsRepository> _lazyModsRepository;

        public RepositoryService(ApplicationDbContext context)
        {
            _lazyMissionRepository = new Lazy<IMissionRepository>(() => new MissionRepository(context));
            _lazyModsRepository = new Lazy<IModsRepository>(() => new ModsRepository(context));
        }

        public IMissionRepository MissionRepository => _lazyMissionRepository.Value;
        public IModsRepository ModsRepository => _lazyModsRepository.Value;
    }
}
