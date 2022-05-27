using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Clientes.Domain.Contracts
{
    public interface IHelper
    {
        Task<string> GetJsonString();
        Task UpdateJson(JArray jArray);
    }
}
