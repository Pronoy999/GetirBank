using GetirBank.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetirBank.Database
{
    public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Balance).IsRequired();

            builder.HasOne(b => b.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CustomerId)
                .HasPrincipalKey(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(a => a.AccountType).IsRequired();
            builder.Property(a => a.CreatedAt).HasDefaultValue(System.DateTime.Now);
        }
    }
}