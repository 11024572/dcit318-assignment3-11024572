using FinanceApp.Models;
using FinanceApp.Interfaces;

namespace FinanceApp.Processors
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Mobile Money] Processed {transaction.Amount:C} for {transaction.Category}.");
        }
    }
}
