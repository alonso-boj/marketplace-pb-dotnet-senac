using Clientes.Application;
using Clientes.Data;
using Clientes.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Clientes.Console
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IClientesService, ClientesService>()
                .AddSingleton<IClientesRepository, ClientesRepository>()
                .AddSingleton<ISerializationService, SerializationService>()
                .AddSingleton<IHelper, Helper>()
                .BuildServiceProvider();

            var _clientesService = serviceProvider.GetService<IClientesService>();

            System.Console.WriteLine("O que você deseja fazer?");
            System.Console.WriteLine(
                @"1 - Criar banco de dados JSON
2 - Ler um registro
3 - Atualizar um registro
4 - Deletar um registro");

            var option = int.Parse(System.Console.ReadLine());

            switch (option)
            {
                case 1:
                    await _clientesService.Create();

                    break;

                case 2:
                    {
                        System.Console.WriteLine("Digite o ID do cliente:");

                        var id = Guid.Parse(System.Console.ReadLine());

                        await _clientesService.Read(id);

                        break;
                    }

                case 3:
                    {
                        System.Console.WriteLine("Digite o ID do cliente:");
                        var id = Guid.Parse(System.Console.ReadLine());

                        System.Console.WriteLine("Digite o novo nome do cliente:");
                        var nome = System.Console.ReadLine();

                        System.Console.WriteLine("Digite a nova data de admissão do cliente:");
                        var dataAdmissao = DateTime.Parse(System.Console.ReadLine());

                        System.Console.WriteLine("Digite o novo salário do cliente:");
                        var salario = decimal.Parse(System.Console.ReadLine());

                        System.Console.WriteLine("Digite a nova comissão do cliente:");
                        var comissao = decimal.Parse(System.Console.ReadLine());

                        System.Console.WriteLine("Digite a nova data de inclusão do cliente:");
                        var dataInclusao = DateTime.Parse(System.Console.ReadLine());

                        await _clientesService.Update(id, nome, dataAdmissao, salario, comissao, dataInclusao);

                        break;
                    }

                case 4:
                    {
                        System.Console.WriteLine("Digite o ID do cliente:");

                        var id = Guid.Parse(System.Console.ReadLine());

                        await _clientesService.Delete(id);

                        break;
                    }

                default: System.Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
