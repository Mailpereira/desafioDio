using DioContaBancaria.Enuns;
using System;
using System.Collections.Generic;

namespace DioContaBancaria
{
    class Program
    {
        static List<Conta> list = new List<Conta>();
        static void Main(string[] args)
        {            
            Console.WriteLine(":::: Bem-vindo ao nosso banco ::::");
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario) 
                {
                    case "1":
                        CriarConta();
                        break;
                    case "2":
                        ListarConta();
                        break;
                    case "3":
                        Transferencia();
                        break;
                    case "4":
                        Saque();
                        break;
                    case "5":
                        Depositar();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }


            
        }

        private static string ObterOpcaoUsuario() 
        {
            Console.WriteLine("Escolha uma opção: ");
            Console.WriteLine();

            Console.WriteLine("1 - Criar Conta");
            Console.WriteLine("2 - Listar Contas");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar valores");
            Console.WriteLine("5 - Depositar valores");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine();
            return opcao;
        }

        private static void CriarConta() 
        {
            Console.WriteLine("Criar Conta");
            Console.Write("Digite 1 para pessoa fisica e 2 para pessoa juridica: ");
            int tipo = int.Parse(Console.ReadLine());

            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite seu saldo inicial: ");
            double saldoInicial = double.Parse(Console.ReadLine());
            Conta conta = new Conta(nome, saldoInicial, (TipoConta)tipo);

            Console.WriteLine(conta);
            list.Add(conta);
        }

        private static void ListarConta() 
        {
            Console.WriteLine("Listar Contas criadas");
            if (list.Count == 0)
            {
                Console.WriteLine("Não existem contas criadas");
            }

            for (int i = 0; i < list.Count; i++)
            {
                Conta conta1 = list[i];
                Console.WriteLine($"#{i} {conta1}");
            }
        }

        private static void Transferencia()
        {
            Console.WriteLine("::: Transferencia entre contas :::");
            Console.Write("Digite o numero da conta de origem: ");
            int indiceOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de destino: ");
            int indiceDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            list[indiceOrigem].Transferir(valorTransferencia, list[indiceDestino]);

        }


        private static void Saque() 
        {
            Console.WriteLine("::: Efetuando Saque :::");
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            list[indiceConta].Sacar(valorSaque);

        }

        private static void Depositar() 
        {
            Console.WriteLine("::: Efetuando Deposito :::");
            Console.Write("Informe o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            list[numeroConta].Deposito(valorDeposito);
        }
    }
}
