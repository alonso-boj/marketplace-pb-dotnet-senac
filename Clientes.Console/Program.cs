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
                .AddSingleton<IFileHelper, FileHelper>()
                .BuildServiceProvider();

            var _clientesService = serviceProvider.GetService<IClientesService>();

            bool execute = true;

            while (execute is true)
            {
                System.Console.Clear();
                System.Console.WriteLine("O que você deseja fazer?");
                System.Console.WriteLine(
                    @"1 - Criar banco de dados JSON
2 - Ler um registro
3 - Ler 10 registros
4 - Atualizar um registro
5 - Deletar um registro
0 - Sair");

                var option = int.Parse(System.Console.ReadLine());

                switch (option)
                {
                    case 1:
                        await _clientesService.Create();

                        break;

                    case 2:
                        {
                            System.Console.WriteLine("Digite o Id do cliente:");

                            var id = Guid.Parse(System.Console.ReadLine());

                            await _clientesService.Read(id);

                            break;
                        }

                    case 3:
                        await _clientesService.Read();

                        break;

                    case 4:
                        {
                            System.Console.WriteLine("Digite o Id do cliente:");
                            var id = Guid.Parse(System.Console.ReadLine());

                            System.Console.WriteLine("Digite o novo nome do cliente:");
                            var nome = System.Console.ReadLine();

                            System.Console.WriteLine("Digite a nova data de admissão do cliente:");
                            var dataAdmissao = DateTime.Parse(System.Console.ReadLine());

                            System.Console.WriteLine("Digite o novo salário do cliente:");
                            var salario = decimal.Parse(System.Console.ReadLine());

                            System.Console.WriteLine("Digite a nova comissão do cliente:");
                            var comissao = decimal.Parse(System.Console.ReadLine());

                            await _clientesService.Update(id, nome, dataAdmissao, salario, comissao);

                            break;
                        }

                    case 5:
                        {
                            System.Console.WriteLine("Digite o Id do cliente:");

                            var id = Guid.Parse(System.Console.ReadLine());

                            await _clientesService.Delete(id);

                            break;
                        }
                    case 0:
                        execute = false;

                        break;

                    default:
                        System.Console.WriteLine("Opção inválida.");

                        break;
                }
            } 
        }
    }
}
