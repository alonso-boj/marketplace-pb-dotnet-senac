using Clientes.Domain.Contracts;
using Clientes.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Clientes.Application
{
    public class SerializationService : ISerializationService
    {
        public async Task<List<Cliente>> DeserializeInputJson()
        {
            var clientList = new List<Cliente>();

            using (var reader = new StreamReader("clientesInput.json"))
            {
                var jsonString = await reader.ReadToEndAsync();

                clientList = JsonConvert.DeserializeObject<List<Cliente>>(jsonString);
            }

            if (clientList is null) throw new Exception("A lista de clientes está vazia.");

            return clientList;
        }
    }
}
