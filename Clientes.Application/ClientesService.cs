using Clientes.Domain.Contracts;
using System;
using System.Threading.Tasks;

namespace Clientes.Application
{
    public class ClientesService : IClientesService
    {
        #region Injeção de dependência pelo construtor. 
        private readonly IClientesRepository _repository;
        private readonly IFileHelper _fileHelper;

        public ClientesService(IClientesRepository repository, IFileHelper fileHelper)
        {
            _repository = repository;
            _fileHelper = fileHelper;
        }
        #endregion

        /* O método Create contém métodos para desserializar o arquivo de input
         * e para utilizar a lista de objetos obtida para criar o banco de dados JSON.
         * O caminho para o arquivo de input é passado via parâmetro no método DeserializeJson. */
        public async Task Create()
        {
            var clientList = await _fileHelper.DeserializeJson(fileLocation: "clientesInput.json");

            await _repository.CreateJsonDatabase(clientList);
        }

        public async Task Read(Guid id)
        {
            await _repository.ReadCustomerById(id);
        }

        public async Task Read()
        {
            await _repository.ReadTenFirstCustomers();
        }

        public async Task Update(Guid id,
            string? nome = null,
            DateTime? dataAdmissao = null,
            decimal? salario = null,
            decimal? comissao = null)
        {
            await _repository.UpdateCustomerById(id, nome, dataAdmissao, salario, comissao);
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteCustomerById(id);
        }
    }
}
