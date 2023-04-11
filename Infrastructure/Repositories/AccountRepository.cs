using Microsoft.EntityFrameworkCore;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Repositories;

namespace PicPayLite.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private ApplicationDbContext _dbContext;
        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Account data)
        {
            _dbContext.Accounts.Add(data);
        }

        public void Delete(Account data)
        {
            _dbContext.Accounts.Remove(data);
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            IEnumerable<Account> data = await _dbContext.Accounts
                .Where(account => account.Id == id)
                .Select(account => account)
                .ToListAsync();

            return data.FirstOrDefault();
        }

        public async Task<Account> GetAccountByNumber(int number)
        {
            IEnumerable<Account> data = await _dbContext.Accounts
                .Where(account => account.Number == number)
                .Select(account => account)
                .ToListAsync();

            return data.FirstOrDefault();
        }
    }
}