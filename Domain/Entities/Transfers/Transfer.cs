namespace PicPayLite.Domain.Tranfers
{
    public class Transfer
    {
        public Guid Id { get; private set; }
        public int Amount{ get; private set; }
        public Sender Sender { get; set; }
        public Recipient Recipient { get; set; }
    }
}