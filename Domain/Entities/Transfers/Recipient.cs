using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Clients;

namespace PicPayLite.Domain.Tranfers
{
    public class Recipient
    {
        public Account Account { get; private set; }
        public string Name { get; private set; }
        public ClientType Type { get; private set; }
    }
}