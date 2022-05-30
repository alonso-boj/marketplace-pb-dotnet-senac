using Clientes.Domain.Contracts;
using Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Data
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly IFileHelper _fileHelper;

        public ClientesRepository(IFileHelper helper)
        {
            _fileHelper = helper;
        }

        public async Task CreateJsonDatabase(List<Cliente> customerList)
        {
            foreach (var customer in customerList)
            {
                customer.Id = Guid.NewGuid();
                customer.DataInclusao = DateTime.Now;
            }

            await _fileHelper.SaveJson(customerList: customerList, fileLocation: "clientesOutput.json");

            Console.WriteLine("Banco de dados JSON gerado com sucesso.");

            Console.ReadKey();
        }

        public async Task ReadCustomerById(Guid id)
        {
            var customerList = await _fileHelper.DeserializeJson(fileLocation: "clientesOutput.json");

            var customer = customerList.FirstOrDefault(customer => customer.Id == id);

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

        public async Task ReadTenFirstCustomers()
        {
            var customerList = await _fileHelper.DeserializeJson(fileLocation: "clientesOutput.json");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(
                @$"
Id: {customerList[i].Id}
Nome: {customerList[i].Nome}
DataAdmissao: {customerList[i].DataAdmissao}
Salario: {customerList[i].Salario}
Comissao: {customerList[i].Comissao}
DataInclusao: {customerList[i].DataInclusao}
DataAlteracao: {customerList[i].DataAlteracao}");
            }

            Console.ReadKey();
        }

        public async Task UpdateCustomerById(
            Guid id,
            string? nome = null,
            DateTime? dataAdmissao = null,
            decimal? salario = null,
            decimal? comissao = null)
        {
            var customerList = await _fileHelper.DeserializeJson(fileLocation: "clientesOutput.json");

            var customer = customerList.FirstOrDefault(customer => customer.Id == id);

            if (nome is not null) customer.Nome = nome;

            if (dataAdmissao is not null) customer.DataAdmissao = (DateTime)dataAdmissao;

            if (salario is not null) customer.Salario = (decimal)salario;

            if (comissao is not null) customer.Comissao = (decimal)comissao;

            customer.DataAlteracao = DateTime.Now;

            await _fileHelper.SaveJson(customerList: customerList, fileLocation: "clientesOutput.json");

            Console.WriteLine("Cliente atualizado com sucesso.");

            Console.ReadKey();
        }

        public async Task DeleteCustomerById(Guid id)
        {
            var customerList = await _fileHelper.DeserializeJson(fileLocation: "clientesOutput.json");

            var customer = customerList.FirstOrDefault(customer => customer.Id == id);

            customerList.Remove(customer);

            await _fileHelper.SaveJson(customerList: customerList, fileLocation: "clientesOutput.json");

            Console.WriteLine("Cliente deletado com sucesso.");

            Console.ReadKey();
        }
    }
}
