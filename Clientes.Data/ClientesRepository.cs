using Clientes.Domain.Contracts;
using Clientes.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Data
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly IHelper _helper;

        public ClientesRepository(IHelper helper)
        {
            _helper = helper;
        }

        public async Task CreateOutputJson(List<Cliente> customerList)
        {
            foreach (var customer in customerList)
            {
                customer.Id = Guid.NewGuid();
                customer.DataInclusao = DateTime.Now;
                customer.DataAlteracao = DateTime.Now;
            }

            var outputJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);

            using (var writer = new StreamWriter("output.json"))
            {
                await writer.WriteAsync(outputJson);
            }

            Console.WriteLine("Banco de dados JSON gerado com sucesso.");

            Console.ReadKey();
        }

        public async Task ReadCustomerById(Guid id)
        {
            string jsonString = await _helper.GetJsonString();

            var jArray = JArray.Parse(jsonString);

            var entry = jArray.FirstOrDefault(entry => entry["id"].Value<string>() == id.ToString());

            var customer = entry.ToObject<Cliente>();

            Console.WriteLine(
                @$"
Id: {customer.Id}
Nome: {customer.Nome}
DataAdmissao: {customer.DataAdmissao}
Salario: {customer.Salario}
Comissao: {customer.Comissao}
DataInclusao: {customer.DataInclusao}
DataAlteracao: {customer.DataAlteracao}");

            Console.ReadKey();
        }

        public async Task UpdateCustomerById(
            Guid id,
            string? nome = null,
            DateTime? dataAdmissao = null,
            decimal? salario = null,
            decimal? comissao = null,
            DateTime? dataInclusao = null)
        {
            var jsonString = await _helper.GetJsonString();

            var jArray = JArray.Parse(jsonString);

            var entry = jArray.FirstOrDefault(entry => entry["id"].Value<string>() == id.ToString());

            if (nome is not null) entry["nome"] = nome;

            if (dataAdmissao is not null) entry["dataAdmissao"] = dataAdmissao;

            if (salario is not null) entry["salario"] = salario;

            if (comissao is not null) entry["comissao"] = comissao;

            if (dataInclusao is not null) entry["dataInclusao"] = dataInclusao;

            entry["dataAlteracao"] = DateTime.Now;

            await _helper.UpdateJson(jArray);

            Console.WriteLine("Cliente atualizado com sucesso.");

            Console.ReadKey();
        }

        public async Task DeleteCustomerById(Guid id)
        {
            var jsonString = await _helper.GetJsonString();

            var jArray = JArray.Parse(jsonString);

            var entry = jArray.FirstOrDefault(entry => entry["id"].Value<string>() == id.ToString());

            entry.Remove();

            await _helper.UpdateJson(jArray);

            Console.WriteLine("Cliente deletado com sucesso.");

            Console.ReadKey();
        }
    }
}
