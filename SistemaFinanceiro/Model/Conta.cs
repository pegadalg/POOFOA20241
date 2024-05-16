using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public decimal Saldo { get => _saldo; }


    }
}
