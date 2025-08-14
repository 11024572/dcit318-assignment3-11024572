using FinanceApp.Models;

namespace FinanceApp.Accounts
{
    public sealed class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance) { }

        public override void ApplyTransaction(Transaction transaction)
        {
            base.ApplyTransaction(transaction);
            Console.WriteLine("Savings account transaction completed.");
        }
    }
}
