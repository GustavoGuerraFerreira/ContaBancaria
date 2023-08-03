using ContaBancaria.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria
{
    internal class Program
    {
        private static List<Cliente> clientes = new List<Cliente>();
        private static List<Conta> contas = new List<Conta>();
        static void Main(string[] args)
        {
            //Populando Clientes:
            Cliente c1 = new Cliente("Marcos", 12345678910);
            Cliente c2 = new Cliente("Marcos", 01987654321);
            Cliente c3 = new Cliente("Marcos", 10293847561);
            clientes.Add(c1);
            clientes.Add(c2);
            clientes.Add(c3);

            //Populando Contas:
            Conta con1 = new Conta(001, c1);
            Conta con2 = new Conta(002, c2);
            Conta con3 = new Conta(003, c3);
            contas.Add(con1);
            contas.Add(con2);
            contas.Add(con3);


            Console.WriteLine("Bem-vindo ao simulador de conta bancária!");

            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Criar Conta");
                Console.WriteLine("3 - Depositar");
                Console.WriteLine("4 - Sacar");
                Console.WriteLine("5 - Consultar Saldo");
                Console.WriteLine("6 - Transferir");
                Console.WriteLine("7 - Sair");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Digite o CPF do cliente:");
                        long cpf = long.Parse(Console.ReadLine());

                        if (clientes.Exists(c => c.Cpf == cpf))
                        {
                            Console.WriteLine("CPF já cadastrado. Não é possível cadastrar cliente com o mesmo CPF.");
                            return;
                        }

                        Console.WriteLine("Digite o nome do cliente:");
                        string nome = Console.ReadLine();

                        clientes.Add(new Cliente(nome, cpf));
                        Console.WriteLine("Cliente cadastrado com sucesso!");
                        break;
                    case "2":
                        Console.WriteLine("Digite o CPF do cliente para vincular à conta:");
                        long validation_cpf = long.Parse(Console.ReadLine());

                     

                        Cliente cliente = clientes.Find(c => c.Cpf == validation_cpf);

                        if (cliente == null)
                        {
                            Console.WriteLine("Cliente não encontrado. Cadastre o cliente antes de criar a conta.");
                            return;
                        }

                        Console.WriteLine("Digite o número da conta:");
                        int numeroConta = int.Parse(Console.ReadLine());

                        if (contas.Exists(c => c.Numero == numeroConta))
                        {
                            Console.WriteLine("Conta já cadastrada. Não é possível cadastrar conta com o mesmo número.");
                            return;
                        }

                        Conta novaConta = new Conta(numeroConta, cliente);
                        contas.Add(novaConta);
                        Console.WriteLine("Conta criada com sucesso!");
                        break;
                    case "3":
                        Console.WriteLine("Digite o número da conta:");
                        int numConta = int.Parse(Console.ReadLine());

                        Conta conta = contas.Find(c => c.Numero == numConta);

                        if (conta == null)
                        {
                            Console.WriteLine("Conta não encontrada.");
                            return;
                        }

                        Console.WriteLine("Digite o valor do depósito:");
                        double valor = double.Parse(Console.ReadLine());
                        conta.Depositar(valor);
                        Console.WriteLine("Valor Depositado com sucesso");
                        break;
                    case "4":
                        Console.WriteLine("Digite o número da conta:");
                        int numberConta = int.Parse(Console.ReadLine());

                        Conta objConta = contas.Find(c => c.Numero == numberConta);

                        if (objConta == null)
                        {
                            Console.WriteLine("Conta não encontrada.");
                            return;
                        }

                        Console.WriteLine("Digite o valor do saque:");
                        double value = double.Parse(Console.ReadLine());
                        objConta.Sacar(value);
                        Console.WriteLine("Valor Sacado com sucesso");
                        break;
                    case "5":
                        Console.WriteLine("Digite o número da conta:");
                        int Conta_number = int.Parse(Console.ReadLine());

                        Conta cont = contas.Find(c => c.Numero == Conta_number);

                        if (cont == null)
                        {
                            Console.WriteLine("Conta não encontrada.");
                            return;
                        }
                        cont.ConsultarSaldo();
                        Console.WriteLine($"Seu Saldo é de: {cont.Saldo}");
                        break;
                    case "6":
                        Console.WriteLine("Digite o número da conta de origem:");
                        int numeroContaOrigem = int.Parse(Console.ReadLine());

                        Conta contaOrigem = contas.Find(c => c.Numero == numeroContaOrigem);

                        if (contaOrigem == null)
                        {
                            Console.WriteLine("Conta de origem não encontrada.");
                            return;
                        }

                        Console.WriteLine("Digite o número da conta de destino:");
                        int numeroContaDestino = int.Parse(Console.ReadLine());

                        Conta contaDestino = contas.Find(c => c.Numero == numeroContaDestino);

                        if (contaDestino == null)
                        {
                            Console.WriteLine("Conta de destino não encontrada.");
                            return;
                        }

                        Console.WriteLine("Digite o valor da transferência:");
                        double qntd_value = double.Parse(Console.ReadLine());
                        contaOrigem.Transferir(qntd_value, contaDestino);
                        Console.WriteLine("Valor transferido com sucesso!");
                        break;
                    case "7":
                        Console.WriteLine("Obrigado por usar o simulador de conta bancária. Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
