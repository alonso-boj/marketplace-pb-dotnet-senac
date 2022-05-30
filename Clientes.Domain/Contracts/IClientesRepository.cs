using Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clientes.Domain.Contracts
{
    public interface IClientesRepository
    {
        Task CreateJsonDatabase(List<Cliente> customerList);
        Task ReadCustomerById(Guid id);
        Task ReadTenFirstCustomers();
        Task UpdateCustomerById(
    Guid id,
    string? nome = null,
    DateTime? dataAdmissao = null,
    decimal? salario = null,
    decimal? comissao = null);
        Task DeleteCustomerById(Guid id);

    }
}
