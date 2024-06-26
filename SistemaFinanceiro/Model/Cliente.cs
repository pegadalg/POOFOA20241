﻿using SistemaFinanceiro.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Model
{
    public class Cliente
    {
        private string nome;
        private string cpf;
        private int anoNascimento;
            
        public Cliente(string nome, string cpf, int anoNascimento)
        {        
            if (!Regex.IsMatch(cpf, @"^\d{11}$"))
            {
                throw new OperacaoInvalidaException("O CPF deve conter 11 caracteres, sendo os 11 apenas números. Programa irá se encerrar");
            }

            if (anoNascimento > DateTime.Now.Year - 18)
            {               
                throw new OperacaoInvalidaException("O Cliente deve ser maior de idade. Programa irá se encerrar");
            }   

            this.nome = nome;
            this.cpf = cpf;
            this.anoNascimento = anoNascimento;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        public int AnoNascimento
        {
            get { return anoNascimento; }
            set { anoNascimento = value; }
        }

        public int Idade
        {
            get { return DateTime.Now.Year - anoNascimento; }
        }

        public string MostrarIdadeEmRomano()
        {
            int idade = Idade;
            string romano = "";
            
                while (idade >= 1000)
                {
                    romano += "M";
                    idade -= 1000;
                }
                if (idade >= 900)
                {
                    romano += "CM";
                    idade -= 900;
                }
                if (idade >= 500)
                {
                    romano += "D";
                    idade -= 500;
                }
                if (idade >= 400)
                {
                    romano += "CD";
                    idade -= 400;
                }
                while (idade >= 100)
                {
                    romano += "C";
                    idade -= 100;
                }
                if (idade >= 90)
                {
                    romano += "XC";
                    idade -= 90;
                }
                if (idade >= 50)
                {
                    romano += "L";
                    idade -= 50;
                }
                if (idade >= 40)
                {
                    romano += "XL";
                    idade -= 40;
                }
                while (idade >= 10)
                {
                    romano += "X";
                    idade -= 10;
                }
                if (idade >= 9)
                {
                    romano += "IX";
                    idade -= 9;
                }
                if (idade >= 5)
                {
                    romano += "V";
                    idade -= 5;
                }
                if (idade >= 4)
                {
                    romano += "IV";
                    idade -= 4;
                }
                while (idade >= 1)
                {
                    romano += "I";
                    idade -= 1;
                }
                return romano;
            
            
        }

    }
}
