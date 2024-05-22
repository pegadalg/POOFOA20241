using SistemaFinanceiro.Exceptions;
using SistemaFinanceiro.Model;
using System.Drawing;

namespace TesteSistemaFinanceiro
{
    
    [TestClass]
    public class ContaTeste
    {
        [TestMethod]
        public void DeveDepositar()
        {
            var conta1 = new Conta(1234, 1000);

            conta1.Depositar(1000);

            Assert.AreEqual(2000, conta1.Saldo);
         
            
        }

        [TestMethod]

        public void DeveSacar()
        {
            var conta1 = new Conta(1234, 1000);
            
            conta1.Sacar(500);

            Assert.AreEqual(500, conta1.Saldo);
               
        }

        [TestMethod]

        public void DeveFalharAoSacar()
        {
            var conta1 = new Conta(1234, 1000);

            var ex = Assert.ThrowsException<OperacaoInvalidaException>( () => conta1.Sacar(1500) );

            Assert.AreEqual($"Valor de saque {1500:C} � maior que o saldo atual.", ex.Message);
        }

        [TestMethod]
        public void DeveFalharAoFazerDeposito()
        {
            var conta1 = new Conta(1234, 1000);


            var ex = Assert.ThrowsException<OperacaoInvalidaException>(() => conta1.Depositar(-1));

            Assert.AreEqual($"O valor de dep�sito: {-1:C} � inv�lido", ex.Message);
        }



    }
}