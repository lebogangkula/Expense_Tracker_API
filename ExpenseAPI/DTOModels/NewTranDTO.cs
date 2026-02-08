namespace ExpenseAPI.DTOModels
{
    public class NewTranDTO
    {
        public int Id { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime UpdatedDate { get; set; }
        public double amount { get; set; }
        public string category { get; set; }

        public string transactType { get; set; }

        public int UserId { get; set; }




    }
}
