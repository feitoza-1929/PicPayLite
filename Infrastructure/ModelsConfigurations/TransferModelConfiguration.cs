using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayLite.Domain.Tranfers;

namespace PicPayLite.Infrastructure.ModelsConfigurations
{
    public class TransferModelConfiguration : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Amount)
                .IsRequired();

            builder.OwnsOne(c => c.Sender, sender =>
            {
                sender
                    .Property(c => c.AccountNumber)
                    .IsRequired();
                sender
                    .Property(c => c.Name)
                    .IsRequired();
                    
                sender.OwnsOne(c => c.Document, document =>
                {
                    document
                        .Property(c => c.type)
                        .HasConversion<int>()
                        .IsRequired();
                    document
                        .Property(c => c.value)
                        .HasMaxLength(14)
                        .IsRequired();
                });
            });

            

            builder.OwnsOne(c => c.Recipient, recipient =>
           {
               recipient
                   .Property(c => c.AccountNumber)
                   .IsRequired();
               recipient
                   .Property(c => c.Name)
                   .IsRequired();

               recipient.OwnsOne(c => c.Document, document =>
               {
                   document
                       .Property(c => c.type)
                       .HasConversion<int>()
                       .IsRequired();
                   document
                       .Property(c => c.value)
                       .HasMaxLength(14)
                       .IsRequired();
               });   
           });

            


            builder.ToTable("Transfers");
        }
    }
}