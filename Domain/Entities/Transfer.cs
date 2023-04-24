using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Domain.Tranfers
{
    public class Transfer
    {
        public Guid Id { get; private set; }
        public float Amount{ get; private set; }
        public TransferPersonData Sender { get; private set; }
        public TransferPersonData Recipient { get; private set; }

        private Transfer(float amount, TransferPersonData sender, TransferPersonData recipient)
        : this(amount)
        {
            Sender = sender;
            Recipient = recipient;
        }

        private Transfer(float amount)
        {
            Amount = amount;
        }

        public static Transfer Create(float amount, TransferPersonData sender, TransferPersonData recipient)
        {
            return new Transfer(amount, sender, recipient);
        }
    }
}