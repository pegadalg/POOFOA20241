using SistemaFinanceiro.Exceptions;
using SistemaFinanceiro.Model;

var conta1 = new Conta(123, 10);
var agencia1 = new Agencia(1237);


Console.WriteLine($"Conta: {conta1.Numero}");
Console.WriteLine($"Saldo: {conta1.Saldo:C}\n");

Console.WriteLine($"Número Agência: {agencia1.Numero}\n");

try 
{
    var valorDeposito = 1000;
    Console.WriteLine($"Valor de deposito inserido é {valorDeposito:C}");
    conta1.Depositar(valorDeposito);
    Console.WriteLine($"Saldo após deposito: {conta1.Saldo:C}\n");

    var valorSaque = 1900;
    Console.WriteLine($"Valor de saque inserido é: {valorSaque:C}");
    conta1.Sacar(valorSaque);
    Console.WriteLine($"Seu saldo após saque é: {conta1.Saldo:C} \n");

}
catch (OperacaoInvalidaException ex)
{
    Console.WriteLine(ex.Message);
}




