using KAST.Application.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Infratructure.Data.Repositories
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
