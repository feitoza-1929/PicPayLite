using PicPayLite.Domain.Accounts;

namespace PicPayLite.Domain.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        List<Account> GetAccountById(Guid id);
        List<Account> GetAccountByNumber(int number);
        
    }
}