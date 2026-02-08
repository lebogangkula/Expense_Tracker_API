using ExpenseAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAPI.DatabaseConnections
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionList>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransactionList>()
                .HasOne(t => t.TransactionType)
                .WithMany(tt => tt.Transactions)
                .HasForeignKey(t => t.TransactionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransactionList>()
                .HasOne(t => t.TransactionsCategory)
                .WithMany(tc => tc.Transactions)
                .HasForeignKey(t => t.TransactionCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransactionType>()
                .HasOne(tt => tt.TransactionsCategory)
                .WithMany(tc => tc.transactionTypes)
                .HasForeignKey(tt => tt.TransactionCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<TransactionType> TransactionType { get; set; }

        public DbSet<TransactionList> Transactions { get; set; }

        public DbSet<TransactionsCategory> TransactionCategory { get; set; }

        public DbSet<User> User { get; set; }

    }
}
