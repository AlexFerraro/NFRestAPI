using NFRestAPI.Infrastructure.EntityTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFRestAPI.Domain.Interfaces
{
    public interface INotaFiscalRepository : IDisposable
    {
        Task<IEnumerable<NotaFiscal>> GetNotaFiscalByEmissionDateAsync(DateTime dataEmissao);

        Task CommitAsync();
    }
}
