using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogulyServer.Persistence.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MogulyContext _mogulyContext;

        public UnitOfWork(MogulyContext mogulyContext)
        {
            _mogulyContext = mogulyContext;
        }

        public async Task SaveChangesAsync()
        {
            await _mogulyContext.SaveChangesAsync();
        }
    }
}
