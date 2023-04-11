using PicPayLite.Domain.Accounts;

namespace PicPayLite.Domain.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetAccountById(Guid id);
        Task<Account> GetAccountByNumber(int number);
        
    }
}