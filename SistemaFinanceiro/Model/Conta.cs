using SistemaFinanceiro.Exceptions;
using System;

//Toda conta deve obrigatoriamente ter um cliente e pertencer a uma agencia,
//sabendo que agencia possui um número, um CEP e um telefone para contato
//e pertence a um banco que possui um nome e um número correspondente;
//Criar métodos dentro de programa para garantir que os objetos atendam aos
//requisitos especificados
//Criar função para informar a idade do clientes em romanos. Orcs também
//podem ser clientes... Quantos anos pode ter um Orc bem velho? (opcional)



namespace SistemaFinanceiro.Model
{
    public class Conta
    {
        private long _numero;
        private decimal _saldo;
        public Agencia agencia;
        public Cliente cliente;  

        public Conta(long numero, decimal saldo, Cliente cliente , Agencia agencia ) 
        {
            _numero = numero;
            _saldo = saldo;
            this.cliente = cliente;
            this.agencia = agencia;

            if (saldo > 10 )
            {
                _saldo = saldo;
            }
            else
            {               
                throw new OperacaoInvalidaException($"O cliente {cliente.Nome} deve ter o saldo maior do que 10");

            }

            if (cliente != null)
            {
                this.cliente = cliente;
            }
            else
            {               
                throw new OperacaoInvalidaException("Cliente não pode ser nulo");

            }
        }

        public long Numero 
        {
            get => _numero;
            private set 
            { 
                _numero = value;
            }

        }

        public decimal Saldo 
        { 
            get => _saldo;
        
        }

        public decimal Depositar(decimal valor)
        {
             
                if (valor > 0)
                {
                    _saldo += valor;
                    return _saldo;
                }

                else
                {
                    //Console.WriteLine("Valor inválido"); 
                    throw new OperacaoInvalidaException($"O valor de depósito: {valor:C} é inválido");
                }
            
            

        }

        public decimal Sacar(decimal valor)
        {
           
                if (_saldo - valor - 0.10m >= 0)
                {
                    _saldo -= valor - 0.10m;
                    return _saldo;
                }

                else 
                {
                    //Console.WriteLine("Valor de saque é maior que o saldo atual.");
                    throw new OperacaoInvalidaException($"Valor de saque {valor:C} é maior que o saldo atual.");
                }
            
           
        }

        public void Transferir(decimal valor, Conta contaDestino)
        {
            if (_saldo - valor >= 0)
            {
                _saldo -= valor;
                contaDestino.Depositar(valor);

                Console.WriteLine($"Transferência realizada com sucesso. Saldo atual: {Saldo:C}");
                Console.WriteLine($"Saldo da conta destino: {contaDestino.Saldo:C}");
            }
            else
            {
                //Console.WriteLine("Saldo insuficiente para transferência");
                throw new OperacaoInvalidaException("Saldo insuficiente para transferência");
            }
        }

        
        // fazer slides 26 30 31 32


    }
}
