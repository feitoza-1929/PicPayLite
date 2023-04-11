using PicPayLite.Domain.Repositories;
using PicPayLite.Domain.Tranfers;

namespace PicPayLite.Infrastructure.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private ApplicationDbContext _dbContext;
        public TransferRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Transfer data)
        {
            _dbContext.Transfers.Add(data);
        }

        public void Delete(Transfer data)
        {
            _dbContext.Transfers.Remove(data);
        }
    }
}
