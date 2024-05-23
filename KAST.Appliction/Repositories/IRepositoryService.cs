using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Application.Repositories
{
    public interface IRepositoryService
    {
        IMissionRepository MissionRepository { get; }
    }
}
