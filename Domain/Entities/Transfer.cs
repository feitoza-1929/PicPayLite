using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Domain.Tranfers
{
    public class Transfer
    {
        public Guid Id { get; private set; }
        public float Amount{ get; private set; }
        public Sender Sender { get; private set; }
        public Recipient Recipient { get; private set; }

        private Transfer(float amount, Sender sender, Recipient recipient)
        : this(amount)
        {
            Sender = sender;
            Recipient = recipient;
        }

        private Transfer(float amount)
        {
            Amount = amount;
        }

        public static Transfer Create(float amount, Sender sender, Recipient recipient)
        {
            return new Transfer(amount, sender, recipient);
        }
    }
}