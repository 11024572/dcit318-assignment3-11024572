using FinanceApp.Models;
using FinanceApp.Interfaces;

namespace FinanceApp.Processors
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Crypto Wallet] Processed {transaction.Amount:C} for {transaction.Category}.");
        }
    }
}
