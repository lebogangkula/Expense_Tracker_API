using ExpenseAPI.Model;

namespace ExpenseAPI.Services
{
    public interface ITransact
    {
        public string UserDetails(User user);

        public string Income(double income);

        public string Expense(double expense);

        
    }
}
