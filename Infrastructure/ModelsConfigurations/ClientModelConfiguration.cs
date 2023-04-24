using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayLite.Domain.Clients;

namespace PicPayLite.Infrastructure.ModelsConfigurations
{
    public class ClientModelConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasAlternateKey(c => c.DocumentValue);

            builder
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(c => c.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(c => c.Type)
                .HasConversion<int>()
                .IsRequired();

            builder
                .Property(c => c.DocumentType)
                .HasConversion<int>()
                .IsRequired();

            builder
                .Property(c => c.DocumentValue)
                .HasMaxLength(14)
                .IsRequired();

            builder.ToTable("Clients");
        }
    }
}