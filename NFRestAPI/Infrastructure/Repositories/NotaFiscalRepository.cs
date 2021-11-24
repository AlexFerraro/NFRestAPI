using NFRestAPI.Domain.Interfaces;
using NFRestAPI.Infrastructure.Contexts;
using NFRestAPI.Infrastructure.EntityTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NFRestAPI.Infrastructure.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private DbContext _context;
        protected DbSet<NotaFiscal> _dbSet;
        private bool disposedValue = false;

        public NotaFiscalRepository(VendasDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<NotaFiscal>();
        }

        public async Task<IEnumerable<NotaFiscal>> GetNotaFiscalByEmissionDateAsync(DateTime dataEmissao) =>
            await _dbSet.AsNoTracking().Where(w => w.Dtemissao == dataEmissao).ToListAsync();

        public async Task CommitAsync()=>
            await _context.SaveChangesAsync().ConfigureAwait(false);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
