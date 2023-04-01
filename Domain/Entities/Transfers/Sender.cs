using PicPayLite.Domain.Accounts;

namespace PicPayLite.Domain.Tranfers
{
    public class Sender
    {
        public Account Account { get; private set; }
        public string Name { get; private set; }
    }
}