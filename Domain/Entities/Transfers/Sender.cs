using System.Reflection.Metadata;
using PicPayLite.Domain.Accounts;

namespace PicPayLite.Domain.Tranfers
{
    public class Sender
    {
        public Document Document { get; private set; }
        public int AccountNumber { get; private set; }
        public string Name { get; private set; }
    }
}