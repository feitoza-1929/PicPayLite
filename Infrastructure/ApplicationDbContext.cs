using Microsoft.EntityFrameworkCore;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Tranfers;
using PicPayLite.Infrastructure.ModelsConfigurations;

namespace PicPayLite.Infrastructure
{
    public class  ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientModelConfiguration());
            modelBuilder.ApplyConfiguration(new AccountModelConfiguration());
            modelBuilder.ApplyConfiguration(new TransferModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}