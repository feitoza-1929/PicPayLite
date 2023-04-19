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

        public List<Account> GetAccountById(Guid id)
        {
            List<Account> data = _dbContext.Accounts
                .Where(account => account.Id == id)
                .Select(account => account)
                .ToList();

            return data;
        }

        public List<Account> GetAccountByNumber(int number)
        {
            List<Account> data = _dbContext.Accounts
                .Where(account => account.Number == number)
                .Select(account => account)
                .ToList();

            return data;
        }
    }
}