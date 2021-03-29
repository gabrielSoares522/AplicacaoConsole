using System;
using DIO.Bank.Enum;

namespace DIO.Bank.Classes
{
    public class Conta
    {
        private string Nome;
        private TipoConta TipoConta;
        private  double Saldo;
        private double Credito;

        public Conta (string no,TipoConta tc,double sa, double cr){
            this.Nome = no;
            this.TipoConta = tc;
            this.Saldo = sa;
            this.Credito = cr;
        }

        public bool sacar( double valor){
            if((this.Saldo - valor) < (this.Credito*-1)){
                Console.WriteLine("Saldo insulficiente!");
                return false;
            }

            this.Saldo -= valor;

            Console.WriteLine("Saldo Atual da conta {0} é R$ {1:0.00}!",this.Nome,this.Saldo);

            return true;
        }

        public void depositar(double valor){
            this.Saldo += valor;

            Console.WriteLine("Saldo Atual da conta {0} é R$ {1:0.00}!",this.Nome,this.Saldo);
        }

        public Conta transferir(Conta conta,double valor){
            if(this.sacar(valor)){
                conta.depositar(valor);
            }
            return conta;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "Tipo Conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;

            return retorno;
        }
    }
}
