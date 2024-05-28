using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Model
{
    public class Banco
    {
        public Agencia Agencia { get; set; }
        public string Nome { get; set; }
        public string NumeroBanco { get; set; }

        public Banco(string nome, string numero, Agencia agencia)
        {
            Nome = nome;
            NumeroBanco = numero;
            Agencia = agencia;
        }
    }
}
