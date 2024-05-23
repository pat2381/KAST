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

        public RepositoryService(ApplicationDbContext context)
        {
            _lazyMissionRepository = new Lazy<IMissionRepository>(() => new MissionRepository(context));
        }

        public IMissionRepository MissionRepository => _lazyMissionRepository.Value;
    }
}
