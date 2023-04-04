using Microsoft.EntityFrameworkCore;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Clients;
using PicPayLite.Domain.Tranfers;

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
    }
}