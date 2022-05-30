using Clientes.Domain.Contracts;
using Clientes.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Clientes.Data
{
    public class FileHelper : IFileHelper
    {
        public async Task<List<Cliente>> DeserializeJson(string fileLocation)
        {
            var clientList = new List<Cliente>();

            using (var reader = new StreamReader(fileLocation))
            {
                var jsonString = await reader.ReadToEndAsync();

                clientList = JsonConvert.DeserializeObject<List<Cliente>>(jsonString);
            }

            if (clientList is null) throw new Exception("A lista de clientes está vazia.");

            return clientList;
        }

        public async Task SaveJson(List<Cliente> customerList, string fileLocation)
        {
            var updatedJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);

            await File.WriteAllTextAsync(fileLocation, updatedJson);
        }
    }
}
