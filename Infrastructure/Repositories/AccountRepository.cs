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
            List<Account> data = await _dbContext.Accounts
                .Where(account => account.Id == id)
                .Select(account => account)
                .ToListAsync();

            return data.FirstOrDefault();
        }

        public async Task<Account> GetAccountByNumber(int number)
        {
            List<Account> data = await _dbContext.Accounts
                .OrderBy(account => account.Number)
                .Where(account => account.Number == number)
                .ToListAsync();

            return data.FirstOrDefault();
        }

        public async Task<bool> AnyAccountNumber(int number)
        {
            return await _dbContext.Accounts.AnyAsync(c => c.Number == number);
        }
    }
}