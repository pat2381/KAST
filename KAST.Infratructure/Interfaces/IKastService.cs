using KAST.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Infratructure.Interfaces
{
    public interface IKastService
    {
        IRepositoryService RepositoryService { get; }

    }
}
