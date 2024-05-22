using SistemaFinanceiro.Exceptions;
using SistemaFinanceiro.Model;

var conta1 = new Conta(123, 1000);

Console.WriteLine($"Conta: {conta1.Numero}");

try 
{ 
    conta1.Depositar(000);
    conta1.Sacar(1900);
}
catch (OperacaoInvalidaException ex)
{
    Console.WriteLine(ex.Message);
}




Console.WriteLine($"Seu saldo atual é: {conta1.Saldo:C}");