using KAST.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Infrastructure.Interfaces
{
    public interface IKastService
    {
        IRepositoryService RepositoryService { get; }

    }
}
