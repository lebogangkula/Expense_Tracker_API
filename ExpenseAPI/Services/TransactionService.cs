using ExpenseAPI.DatabaseConnections;
using ExpenseAPI.DTOModels;
using ExpenseAPI.Model;
using System.Linq;

namespace ExpenseAPI.Services
{
    public class TransactionService(DataContext context) : ITransectionService


    {
        public string DeleteTransction(int Id)
        {
            var data = context.Transactions.Find(Id);
            if (data != null)
            {
                context.Transactions.Remove(data);
                context.SaveChanges();
                return "Transaction deleted";
            }
            return "No transaction Found";
        }

        public IEnumerable<TransactionsDTO> getAllTransactions()
        {
          
          var Transactions = context.Transactions.Select(y => new TransactionsDTO {


               Id = y.Id,

               CreatedDate = y.CreatedDate,

               UpdatedDate = y.UpdatedDate,

               Amount = y.Amount,

               TransactionCategoryId = y.TransactionCategoryId,

               TransactionTypeId = y.TransactionTypeId,

               UserId = y.UserId

    }).ToList();

           return Transactions;
        }

        public IEnumerable<TransactionCategoryDTO> GetCategories()
        {
          
            var categories = context.TransactionCategory.Select(u => new TransactionCategoryDTO
            {
                  TransactionCategory = u.TransactionCategory
            }).ToList();
            
            return categories;
        }

        public NewTransactDTO getTransactionById(int Id)
        {
            NewTransactDTO transaction = new NewTransactDTO();
            transaction.amount = context.Transactions.Where(u => u.Id == Id).Select(u => u.Amount).FirstOrDefault();
            transaction.category = context.TransactionCategory.Where(u => u.TransactionCategoryId == context.Transactions.Where(u => u.Id == Id).Select(u => u.TransactionCategoryId).FirstOrDefault()).Select(u => u.TransactionCategory).FirstOrDefault();
            transaction.transactType = context.TransactionType.Where(u => u.TransactiontTypeId == context.Transactions.Where(u => u.Id == Id).Select(u => u.TransactionTypeId).FirstOrDefault()).Select(u => u.TransactType).FirstOrDefault();
            transaction.createdAt = context.Transactions.Where(u => u.Id == Id).Select(u => u.CreatedDate).FirstOrDefault();

            return transaction;
        }

        public IEnumerable<TransactionTypeDTO> GetTransactionTypes(int Id)
        {
            var transactionTypes = context.TransactionType.Where(u => u.TransactionCategoryId == Id).Select(u => new TransactionTypeDTO
            {
                TransactType = u.TransactType

            }).ToList();

            return transactionTypes;
        }

        public NewTransactDTO MakeTransaction(NewTransactDTO transaction)
        {
    
            var transactionDTO = new TransactionList();
            transactionDTO.CreatedDate= transaction.createdAt;
            transactionDTO.UpdatedDate = transaction.createdAt;
            transactionDTO.Amount = transaction.amount;
            
            transactionDTO.TransactionCategoryId = context.TransactionCategory.Where(u => u.TransactionCategory == transaction.category).Select(u => u.TransactionCategoryId).FirstOrDefault();

            transactionDTO.TransactionTypeId = context.TransactionType.Where(u => u.TransactType == transaction.transactType).Select(u => u.TransactiontTypeId).FirstOrDefault();
            transactionDTO.UserId = 5;
            context.Transactions.Add(transactionDTO);
            context.SaveChanges();
            return transaction;


    }

        public NewTransactDTO updateTransactionRecord(int Id, NewTransactDTO transaction)
        {
            var item = context.Transactions.Find(Id);
            item.TransactionCategoryId = context.TransactionCategory.Where(u => u.TransactionCategory == transaction.category).Select(u => u.TransactionCategoryId).FirstOrDefault();
            item.TransactionTypeId = context.TransactionType.Where(u => u.TransactType == transaction.transactType).Select(u => u.TransactiontTypeId).FirstOrDefault();
            item.UpdatedDate = DateTime.Now;
            item.Amount = transaction.amount;
            context.Transactions.Update(item);
            context.SaveChanges();

            return transaction;
        }


    }
}
