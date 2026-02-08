using System.ComponentModel.DataAnnotations;

namespace ExpenseAPI.Model
{
    public class TransactionType
    {
        [Key]
        public int Id { get; set; }

        public string TransactType { get; set; }
    }
}
