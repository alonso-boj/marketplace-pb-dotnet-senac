using Clientes.Domain.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Clientes.Data
{
    public class Helper : IHelper
    {
        public async Task<string> GetJsonString()
        {
            string jsonString;

            using (var reader = new StreamReader("output.json"))
            {
                jsonString = await reader.ReadToEndAsync();
            }

            return jsonString;
        }

        public async Task UpdateJson(JArray jArray)
        {
            var updatedJson = JsonConvert.SerializeObject(jArray, Formatting.Indented);

            await File.WriteAllTextAsync("output.json", updatedJson);
        }
    }
}
