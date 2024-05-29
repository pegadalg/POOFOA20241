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
            //cenário
            var cliente1 = new Cliente("João", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000,cliente1);
            //Ação
            conta1.Depositar(1000);
            //verificação
            Assert.AreEqual(2000, conta1.Saldo);        
        }

        [TestMethod]

        public void DeveSacar()
        {
            //cenário
            var cliente1 = new Cliente("João", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000,cliente1);
            //Ação
            conta1.Sacar(500);
            //verificação
            Assert.AreEqual(499.90m , conta1.Saldo);             
        }

        [TestMethod]

        public void DeveFalharAoSacar()
        {
            //cenário
            var cliente1 = new Cliente("João", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000, cliente1);
            //Ação
            var ex = Assert.ThrowsException<OperacaoInvalidaException>( () => conta1.Sacar(1500) );
            //verificação
            Assert.AreEqual($"Valor de saque {1500:C} é maior que o saldo atual. Programa irá se encerrar", ex.Message);
        }

        [TestMethod]
        public void DeveFalharAoFazerDeposito()
        {
            //cenário
            var cliente1 = new Cliente("João", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000, cliente1);
            //Ação
            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Depositar(-1));
            //verificação
            Assert.AreEqual($"O valor de depósito: {-1:C} é inválido. Programa irá se encerrar", ex.Message);
        }

        [TestMethod]

        public void DeveTransferir()
        {
            //cenário
            var cliente1 = new Cliente("João", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000, cliente1);
            var cliente2 = new Cliente("Maria", "12345678901", 2000);
            var conta2 = new Conta(1235, 1000, cliente2);
            //Ação
            conta1.Transferir(100, conta2);
            //verificação
            Assert.AreEqual(900, conta1.Saldo);
            Assert.AreEqual(1100, conta2.Saldo);
        }

        [TestMethod]

        public void DeveFalharAoTransferir()
        {
            //cenário
            var cliente1 = new Cliente("João", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000, cliente1);
            var cliente2 = new Cliente("Maria", "12345678901", 2000);
            var conta2 = new Conta(1235, 1000, cliente2);
            //Ação
            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Transferir(2000, conta2));
            //verificação
            Assert.AreEqual("Saldo insuficiente para transferência. Programa irá se encerrar", ex.Message);
        }

        [TestMethod]

        public void DeveFalharAoTransferirValorInvalido()
        {
            //cenário
            var cliente1 = new Cliente("João", "12345678901", 2000);
            var conta1 = new Conta(1234, 1000, cliente1);
            var cliente2 = new Cliente("Maria", "12345678901", 2000);
            var conta2 = new Conta(1235, 1000, cliente2);
            //Ação
            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Transferir(-1, conta2));
            //verificação
            Assert.AreEqual("O valor de transferência é inválido. Programa irá se encerrar", ex.Message);
        }

        [TestMethod]

        public void DeveMostrarIdadeEmRomano()
        {
            //cenário
            var cliente1 = new Cliente("João", "12345678901", 2000);
            //Ação
            cliente1.MostrarIdadeEmRomano();
            //verificação
            Assert.AreEqual("XXIV", cliente1.MostrarIdadeEmRomano());
        }

        [TestMethod]

        public void DeveFalharAoMostrarIdadeEmRomano()
        {
            
            //Ação
            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => new Cliente("João", "12345678901", 2024));
            //verificação
            Assert.AreEqual("O Cliente deve ser maior de idade. Programa irá se encerrar", ex.Message);
        }



    }
}