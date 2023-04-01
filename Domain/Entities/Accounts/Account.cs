namespace PicPayLite.Domain.Accounts
{
    public class Account
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public int Number { get; private set; }
        public Balance balance { get; private set;} 
    }
}