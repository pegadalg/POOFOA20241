using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaFinanceiro.Model
{
    public class Agencia
    {
        
        private int _numero;
        private string _nome, _telefone;
        

        public Agencia(int numero) 
        {
            this._numero = numero;
        }

        public int Numero
        {
            get => _numero;           
        }

        public string nome
        {
            get => _nome;
            set => _nome = value;
        }

        public string Telefone
        {
            get => _telefone;
            set => _telefone = value;
        }







    }
}
