using Clientes.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clientes.Domain.Contracts
{
    public interface IFileHelper
    {
        Task<List<Cliente>> DeserializeJson(string fileLocation);
        Task SaveJson(List<Cliente> customerList, string fileLocation);
    }
}
