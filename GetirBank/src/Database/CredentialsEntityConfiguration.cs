using GetirBank.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Crypto.Tls;

namespace GetirBank.Database
{
    public class CredentialsEntityConfiguration:IEntityTypeConfiguration<Credentials>
    {
        public void Configure(EntityTypeBuilder<Credentials> builder)
        {
            builder.Property(c => c.Password).IsRequired();
            
            builder.HasOne(c => c.Customer)
                .WithOne(c => c.Credentials)
                .HasForeignKey<Credentials>(c => c.Email)
                .HasPrincipalKey<Customer>(u => u.EmailId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired();

            builder.Property(c => c.IsActive).HasDefaultValue(true);
            builder.Property(c => c.CreatedAt).HasDefaultValue(System.DateTime.Now);
        }
    }
}