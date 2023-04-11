namespace PicPayLite.Domain.Tranfers
{
    public class Transfer
    {
        public Guid Id { get; private set; }
        public float Amount{ get; private set; }
        public Sender Sender { get; private set; }
        public Recipient Recipient { get; private set; }

        private Transfer(float amount, Sender sender, Recipient recipient)
        {
            Amount = amount;
            Sender = sender;
            Recipient = recipient;
        }

        public static Transfer Create(float amount, Sender sender, Recipient recipient)
        {
            return new Transfer(amount, sender, recipient);
        }
    }
}