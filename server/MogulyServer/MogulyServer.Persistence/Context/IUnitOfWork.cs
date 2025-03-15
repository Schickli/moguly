using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Persistence.Context
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
