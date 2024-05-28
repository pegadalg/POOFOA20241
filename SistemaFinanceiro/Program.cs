using SistemaFinanceiro.Exceptions;
using SistemaFinanceiro.Model;
using static System.Net.Mime.MediaTypeNames;

try 
{
    Cliente cliente1 = new Cliente("João", "12345678901", 2000);
    Cliente cliente2 = new Cliente("Maria", "09876543210", 1990);
    var agencia1 = new Agencia(1237);

    var conta1 = new Conta(123, 100, cliente1, agencia1);
    var conta2 = new Conta(654321, 2341.42m, cliente2, agencia1);



    Console.WriteLine($"Conta: {conta1.Numero}");
    Console.WriteLine($"Saldo: {conta1.Saldo:C}\n");

    Console.WriteLine($"Conta: {conta2.Numero}");
    Console.WriteLine($"Saldo: {conta2.Saldo:C}\n");

    Console.WriteLine($"Número Agência: {agencia1.Numero}\n");


    var SaldoInicialConta1 = conta1.Saldo;
    var SaldoInicialConta2 = conta2.Saldo;

    var SaldoInicialTotalGeral = SaldoInicialConta1 + SaldoInicialConta2;


    var valorDeposito = 5000;
    Console.WriteLine($"Conta 1 - Cliente: {cliente1.Nome}");
    Console.WriteLine($"Valor de deposito inserido é {valorDeposito:C}"); 
    conta1.Depositar(valorDeposito);
    Console.WriteLine($"Saldo após deposito: {conta1.Saldo:C}\n");

    var valorSaque = 1900;
    Console.WriteLine($"Valor de saque inserido é: {valorSaque:C}");
    conta1.Sacar(valorSaque);
    Console.WriteLine($"Seu saldo após saque é: {conta1.Saldo:C} \n");
    //
    Console.WriteLine($"Conta 2 - Cliente: {cliente2.Nome}");
    Console.WriteLine($"Valor de deposito inserido é {valorDeposito:C}");
    conta2.Depositar(valorDeposito);
    Console.WriteLine($"Saldo após deposito: {conta2.Saldo:C}\n");

    Console.WriteLine($"Valor de saque inserido é: {valorSaque:C}");
    conta2.Sacar(valorSaque);
    Console.WriteLine($"Seu saldo após saque é: {conta2.Saldo:C} \n");




    var saldoTotal = conta1.Saldo + conta2.Saldo;
    Console.WriteLine($"Saldo total das duas contas: {saldoTotal:C}");

    if (conta1.Saldo > conta2.Saldo)
    {
        Console.WriteLine($"Conta com maior saldo: {conta1.Numero}");
    }
    else
    {
        Console.WriteLine($"Conta com maior saldo: {conta2.Numero}");
    }

    Console.WriteLine($"Saldo inicial total conta 1: {SaldoInicialConta1:C}");
    Console.WriteLine($"Saldo inicial total conta 2: {SaldoInicialConta2:C}");
    Console.WriteLine($"Saldo inicial Total Geral: {SaldoInicialTotalGeral:C}");

    Console.WriteLine("\n");
    Console.WriteLine("\n");

    conta1.Transferir(100, conta2);


    cliente1.MostrarIdadeEmRomano();
    cliente2.MostrarIdadeEmRomano();


}
catch (OperacaoInvalidaException ex)
{
   
    Console.WriteLine(ex.Message);
    
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    
}




