using SistemaFinanceiro.Exceptions;

namespace SistemaFinanceiro.Model
{
    public class Conta
    {
        private long _numero;
        private decimal _saldo;

        public Conta(long numero)
        {
            _numero = numero;
        }

        public Conta(long numero, decimal saldo) 
        {
            _numero = numero;
            _saldo = saldo;
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

        public void Depositar(decimal valor)
        {
             
                if (valor <= 0)
                {
                    //Console.WriteLine("Valor inválido"); 
                    throw new OperacaoInvalidaException($"O valor de depósito: {valor:C} é inválido");
                }
                else
                {
                    _saldo += valor;
                Console.WriteLine($"Depósito de {valor:C} realizado com sucesso");
                }
            
            

        }

        public void Sacar(decimal valor)
        {
           
                if (valor > _saldo)
                {
                    //Console.WriteLine("Valor de saque é maior que o saldo atual.");
                    throw new OperacaoInvalidaException($"Valor de saque {valor:C} é maior que o saldo atual.");
                }
                else
                {
                    Console.WriteLine($"Seu saldo era de {_saldo:C}");
                    _saldo -= valor;
                    Console.WriteLine($"Saque de {valor:C} realizado com sucesso");
                }
            
           
        }

        



    }
}
