using FinanceApp.Models;
using FinanceApp.Processors;
using FinanceApp.Accounts;
using FinanceApp.Interfaces;

class Program
{
    static void Main()
    {
        var transaction = new Transaction(1, DateTime.Now, 100.50m, "Utilities");

        ITransactionProcessor bankProcessor = new BankTransferProcessor();
        bankProcessor.Process(transaction);

        Account myAccount = new SavingsAccount("ACC12345", 500m);
        myAccount.ApplyTransaction(transaction);
    }
}
