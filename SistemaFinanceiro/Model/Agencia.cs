using SistemaFinanceiro.Exceptions;
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
        private string _cep;
        private List<Conta> _contas = new List<Conta>();
        

        public Agencia(int numero , Conta conta) 
        {
            if (conta == null)
            {
                throw new OperacaoInvalidaException("Conta não pode ser nula. Programa irá se encerrar");
            }

            _numero = numero;
            Contas.Add(conta);
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

        public string Cep
        {
            get => _cep;
            set => _cep = value;
        }
        public List<Conta> Contas
        {
            get => _contas;
        }





    }
}
