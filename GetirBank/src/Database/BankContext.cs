using GetirBank.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace GetirBank.Database
{
    public class BankContext : DbContext
    {
        public DbSet<Customer> Customers;
        public DbSet<Account> Accounts;
        public DbSet<Transaction> Transactions;

        public BankContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CustomerEntityConfiguration().Configure(modelBuilder.Entity<Customer>());
            new AccountEntityConfiguration().Configure(modelBuilder.Entity<Account>());
            new TransactionEntityConfiguration().Configure(modelBuilder.Entity<Transaction>());
            new CredentialsEntityConfiguration().Configure(modelBuilder.Entity<Credentials>());
        }
    }
}