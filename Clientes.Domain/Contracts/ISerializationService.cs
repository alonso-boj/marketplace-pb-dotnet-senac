using Clientes.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clientes.Domain.Contracts
{
    public interface ISerializationService
    {
        Task<List<Cliente>> DeserializeInputJson();
    }
}