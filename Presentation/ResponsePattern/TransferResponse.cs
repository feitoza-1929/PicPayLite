using PicPayLite.Domain.Tranfers;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Presentation.ResponsePattern
{
    public class TransferResponse
    {
        public float Amount { get; private set; }
        public int Sender { get; private set; }
        public int Recipient { get; private set; }

        private TransferResponse(int senderAccount, int recipientAccount, float amount)
        {
            Sender = senderAccount;
            Recipient = recipientAccount;
            Amount = amount;
        }

        public static TransferResponse Create(Transfer transfer)
        {
            return new TransferResponse(
                transfer.Sender.AccountNumber,
                transfer.Recipient.AccountNumber,
                transfer.Amount);
        }
    }
}