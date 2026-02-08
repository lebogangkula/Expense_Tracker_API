using ExpenseAPI.DTOModels;
using ExpenseAPI.Model;

namespace ExpenseAPI.Services
{
    public interface ITransectionService 
    {
        public IEnumerable<TransactionCategoryDTO> GetCategories();

        public IEnumerable<TransactionTypeDTO> GetTransactionTypes(int Id);

        public IEnumerable<TransactionsDTO> getAllTransactions();

        public NewTransactDTO MakeTransaction(NewTransactDTO transaction);

        public string DeleteTransction(int Id);

        public NewTransactDTO updateTransactionRecord(int Id, NewTransactDTO transaction);

        public NewTransactDTO getTransactionById(int Id);

    }
}
