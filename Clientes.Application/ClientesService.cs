using Clientes.Domain.Contracts;
using System;
using System.Threading.Tasks;

namespace Clientes.Application
{
    public class ClientesService : IClientesService
    {
        private readonly IClientesRepository _repository;
        private readonly ISerializationService _serializationService;

        public ClientesService(IClientesRepository repository, ISerializationService serializationService)
        {
            _repository = repository;
            _serializationService = serializationService;
        }

        public async Task Create()
        {
            var clientList = await _serializationService.DeserializeInputJson();

            await _repository.CreateOutputJson(clientList);
        }

        public async Task Read(Guid id) => await _repository.ReadCustomerById(id);

        public async Task Update(Guid id,
            string? nome = null,
            DateTime? dataAdmissao = null,
            decimal? salario = null,
            decimal? comissao = null,
            DateTime? dataInclusao = null) => await _repository.UpdateCustomerById(id, nome, dataAdmissao, salario, comissao, dataInclusao);

        public async Task Delete(Guid id) => await _repository.DeleteCustomerById(id);
    }
}
