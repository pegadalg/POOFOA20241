using SistemaFinanceiro.Exceptions;

namespace SistemaFinanceiro.Model
{
    public class Conta
    {
        private long _numero;
        private decimal _saldo;
        public Agencia agencia;

        public Conta(long numero)
        {
            this._numero = numero;
        }

        public Conta(long numero, decimal saldo) 
        {
            this._numero = numero;


            if (saldo > 10 )
            {
                _saldo = saldo;
            }
            else
            {
                Console.WriteLine("Seu saldo deve ser maior do que 10");
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
           
                if (_saldo - valor >= 0)
                {
                    _saldo -= valor;
                    return _saldo;
                }

                else 
                {
                    //Console.WriteLine("Valor de saque é maior que o saldo atual.");
                    throw new OperacaoInvalidaException($"Valor de saque {valor:C} é maior que o saldo atual.");
                }
            
           
        }

        
        // fazer slides 26 30 31 32


    }
}
