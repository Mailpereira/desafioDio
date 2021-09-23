using DioContaBancaria.Enuns;
using System;

namespace DioContaBancaria
{
    class Conta
    {
        private string _nome { get; set; }
        private double _saldo { get; set; }
        private TipoConta _tipoConta { get; set; }

        public Conta(string nome, double saldo, TipoConta tipo) 
        {
            this._nome = nome;
            this._saldo = saldo;
            this._tipoConta = tipo;
        }

        public bool Sacar(double valorSaque) 
        {
            if (valorSaque > this._saldo ) 
            {
                Console.WriteLine("Saldo Insufiente");
                return false;
            }
            this._saldo -= valorSaque;
            Console.WriteLine("::: Saque efetuado com sucesso :::");
            Console.WriteLine($"Informações: {this._nome}, saque: {this._saldo}");
            return true;
        }

        public void Deposito(double deposito) 
        {
            this._saldo += deposito;
            Console.WriteLine("::: Deposito Efetuado com sucesso :::");
            Console.WriteLine($"Dados atualizados: {this._nome}, Saldo: {this._saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino) 
        {
            if (this.Sacar(valorTransferencia)) 
            {
                contaDestino.Deposito(valorTransferencia);
            }
        }

        public override string ToString()
        {
            return $"Dados da conta {this._nome}, Tipo: {this._tipoConta} e Saldo Inicial: {this._saldo}";
        }



    }
}
