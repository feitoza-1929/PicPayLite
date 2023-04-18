using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayLite.Domain.Accounts;
namespace PicPayLite.Infrastructure.ModelsConfigurations
{
    public class AccountModelConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(c => c.Client)
                .WithOne(c => c.Account)
                .HasForeignKey<Account>(c => c.ClientId)
                .IsRequired();

            builder
                .Property(c => c.Number)
                .IsRequired();

            builder.OwnsOne(c => c.Balance, balance =>
            {
                balance
                    .Property(c => c.Currency)
                    .HasMaxLength(3)
                    .IsRequired();

                balance
                    .Property(c => c.Amount)
                    .IsRequired();
            });

            builder.ToTable("Accounts");
        }
    }
}