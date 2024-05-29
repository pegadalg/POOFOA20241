using SistemaFinanceiro.Exceptions;
using System;

namespace SistemaFinanceiro.Model
{
    public class Conta
    {
        private long _numero;
        private decimal _saldo;      
        private Cliente _cliente;
        public decimal tarifa = 0.10m;

        public Conta(long numero, decimal saldo, Cliente cliente  ) 
        {
            _numero = numero;
            _saldo = saldo;
            _cliente = cliente;            

            if (saldo > 10 )
            {
                _saldo = saldo;
            }
            else
            {               
                throw new OperacaoInvalidaException($"O cliente {cliente.Nome} deve ter o saldo maior do que 10. Programa irá se encerrar");

            }

            if (cliente != null)
            {
                _cliente = cliente;
            }
            else
            {               
                throw new OperacaoInvalidaException("Cliente não pode ser nulo. Programa irá se encerrar");

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
        public Cliente Cliente
        {
            get => _cliente;
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
                    throw new OperacaoInvalidaException($"O valor de depósito: {valor:C} é inválido. Programa irá se encerrar");
                }                  
        }
        
        public decimal Sacar(decimal valor)
        {
           if (valor > 0)
            { 
                if (_saldo - (valor + tarifa) >= 0)
                {
                    _saldo -= valor + tarifa;
                    return _saldo;
                }

                else 
                {
                    throw new OperacaoInvalidaException($"Valor de saque {valor:C} é maior que o saldo atual. Programa irá se encerrar");
                }
            }
           else
            {
                throw new OperacaoInvalidaException($"O valor de saque: {valor:C} é inválido. Programa irá se encerrar");
            }

        }

        public void Transferir(decimal valor, Conta contaDestino)
        {
            if (valor <= 0)
            {
                throw new OperacaoInvalidaException($"O valor de transferência é inválido. Programa irá se encerrar");
            }
            else if (_saldo - valor >= 0)
            {
                contaDestino.Depositar(valor);
                _saldo -= valor;
                

                Console.WriteLine($"Transferência da conta {Numero} para a conta {contaDestino.Numero} realizada com sucesso. Saldo atual: {Saldo:C}");
                Console.WriteLine($"Saldo da conta destino: {contaDestino.Saldo:C}");
            }
            else
            {
                throw new OperacaoInvalidaException("Saldo insuficiente para transferência. Programa irá se encerrar");
            }
        }
    }
}
