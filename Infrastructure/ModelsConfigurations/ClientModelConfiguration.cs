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

            builder.OwnsOne(c => c.Document, document =>
            {
                document
                    .Property(d => d.type)
                    .HasConversion<int>()
                    .IsRequired();

                document
                    .Property(d => d.value)
                    .HasMaxLength(14)
                    .IsRequired();
            });

            builder.ToTable("Clients");
        }
    }
}