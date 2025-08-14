using FinanceApp.Models;

namespace FinanceApp.Interfaces
{
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }
}
