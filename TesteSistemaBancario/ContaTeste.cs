using SistemaFinanceiro.Exceptions;
using SistemaFinanceiro.Model;
using System.Drawing;

namespace SistemaFinanceiroTeste
{
    
    [TestClass]
    public class ContaTeste
    {
        [TestMethod]
        public void DeveDepositar()
        {
            //cen�rio
            var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000,cliente1);
            //A��o
            conta1.Depositar(1000);
            //verifica��o
            Assert.AreEqual(2000, conta1.Saldo);        
        }

        [TestMethod]

        public void DeveSacar()
        {
            //cen�rio
            var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000,cliente1);
            //A��o
            conta1.Sacar(500);
            //verifica��o
            Assert.AreEqual(499.90m , conta1.Saldo);             
        }

        [TestMethod]

        public void DeveFalharAoSacar()
        {
            //cen�rio
            var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000, cliente1);
            //A��o
            var ex = Assert.ThrowsException<OperacaoInvalidaException>( () => conta1.Sacar(1500) );
            //verifica��o
            Assert.AreEqual($"Valor de saque {1500:C} � maior que o saldo atual. Programa ir� se encerrar", ex.Message);
        }

        [TestMethod]
        public void DeveFalharAoFazerDeposito()
        {
            //cen�rio
            var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000, cliente1);
            //A��o
            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Depositar(-1));
            //verifica��o
            Assert.AreEqual($"O valor de dep�sito: {-1:C} � inv�lido. Programa ir� se encerrar", ex.Message);
        }

        [TestMethod]

        public void DeveTransferir()
        {
            //cen�rio
            var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000, cliente1);
            var cliente2 = new Cliente("Maria", "12345678901", 2000);
            var conta2 = new Conta(1235, 1000, cliente2);
            //A��o
            conta1.Transferir(100, conta2);
            //verifica��o
            Assert.AreEqual(900, conta1.Saldo);
            Assert.AreEqual(1100, conta2.Saldo);
        }

        [TestMethod]

        public void DeveFalharAoTransferir()
        {
            //cen�rio
            var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000, cliente1);
            var cliente2 = new Cliente("Maria", "12345678901", 2000);
            var conta2 = new Conta(1235, 1000, cliente2);
            //A��o
            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Transferir(2000, conta2));
            //verifica��o
            Assert.AreEqual("Saldo insuficiente para transfer�ncia. Programa ir� se encerrar", ex.Message);
        }

        [TestMethod]

        public void DeveFalharAoTransferirValorInvalido()
        {
            //cen�rio
            var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000, cliente1);
            var cliente2 = new Cliente("Maria", "12345678901", 2000);
            var conta2 = new Conta(1235, 1000, cliente2);
            //A��o
            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Transferir(-1, conta2));
            //verifica��o
            Assert.AreEqual("O valor de transfer�ncia � inv�lido. Programa ir� se encerrar", ex.Message);
        }

        [TestMethod]

        public void DeveMostrarIdadeEmRomano()
        {
            //cen�rio
            var cliente1 = new Cliente("Jo�o", "12345678901", 2000);
            //A��o
            cliente1.MostrarIdadeEmRomano();
            //verifica��o
            Assert.AreEqual("XXIV", cliente1.MostrarIdadeEmRomano());
        }

        [TestMethod]

        public void DeveFalharAoMostrarIdadeEmRomano()
        {
            
            //A��o
            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Cliente("Jo�o", "12345678901", 2024));
            //verifica��o
            Assert.AreEqual("O Cliente deve ser maior de idade. Programa ir� se encerrar", ex.Message);
        }



    }
}