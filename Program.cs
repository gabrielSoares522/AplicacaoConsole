using System;
using DIO.Bank.Classes;
using DIO.Bank.Enum;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        public static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            do {
                string opcao = opcaoUsuario();

                switch(opcao){
                    case "1":
                        listarContas();
                        break;
                    case "2":
                        inserirContas();
                        break;
                    case "3":
                        transferir();
                        break;
                    case "4":
                        sacar();
                        break;
                    case "5":
                        depositar();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    case "x":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Arguento invalido!");
                        break;
                }
                if (opcao == "x") {
                    break;
                }
            }while(true);
        }


        private static void listarContas(){
            Console.WriteLine("LISTA DE CONTAS");
            if(listaContas.Count == 0){
                Console.WriteLine("Lista vazia");
                return;
            }
            for(int i=0;i<listaContas.Count;i++) {
                Console.WriteLine("#========================================#");
                Console.WriteLine(listaContas[i].ToString());                
            }

            Console.ReadKey();
        }

        private static void inserirContas(){
            Console.WriteLine("INSERIR CONTAS");

            Console.Write("Digite 1 para conta fisica e 2 para conta juridica: ");
            int tipo = int.Parse(Console.ReadLine());

            Console.Write("Nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Credito inicial: ");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(nome,TipoConta.pessoaJuridica,saldo,credito);
            listaContas.Add(novaConta);
        }

        private static void transferir(){
            Console.WriteLine("TRANSFERIR DINHEIRO");

            Console.Write("Digite o numero da conta de saque: ");
            int indiceSaque = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de deposito: ");
            int indiceDeposito = int.Parse(Console.ReadLine());

            Console.Write("Valor de transferencia: ");
            double valor = double.Parse(Console.ReadLine());

            listaContas[indiceDeposito] = listaContas[indiceSaque].transferir(
                listaContas[indiceDeposito],
                valor);
            
        }

        private static void sacar(){
            Console.WriteLine("REALIZAR SAQUE");

            Console.Write("Digite o numero da conta: ");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("Valor do saque: ");
            double valor = double.Parse(Console.ReadLine());

            listaContas[indice].sacar(valor);
            //salvar();
        }

        private static void depositar(){
            Console.WriteLine("DEPOSITAR CONTA");

            Console.Write("Digite o numero da conta: ");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("valor deposito: ");
            double valor = double.Parse(Console.ReadLine());

            listaContas[indice].depositar(valor);
        }

        private static string opcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("BANCO DO LITORAL");
            Console.WriteLine("Digite a opção: ");
            
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("c - Limpar tela");
            Console.WriteLine("x - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToLower();
            Console.WriteLine();
            return opcao;
        }
    }
}
