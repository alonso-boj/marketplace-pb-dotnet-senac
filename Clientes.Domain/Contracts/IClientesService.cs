using System;
using System.Threading.Tasks;

namespace Clientes.Domain.Contracts
{
    public interface IClientesService
    {
        Task Create();
        Task Read(Guid id);
        Task Update(Guid id,
            string? nome = null,
            DateTime? dataAdmissao = null,
            decimal? salario = null,
            decimal? comissao = null,
            DateTime? dataInclusao = null);
        Task Delete(Guid id);
    }
}
