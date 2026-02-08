using System.ComponentModel.DataAnnotations;

namespace ExpenseAPI.Model
{
    public class TransactionsCategory
    {
        [Key]
        public int TransactionId { get; set; }

        public string TransactionType { get; set; }

        


    }
}
