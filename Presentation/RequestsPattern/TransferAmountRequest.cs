using System.ComponentModel.DataAnnotations;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Presentation.RequestsPattern
{
    public class TransferAmountRequest
    {
        public int Amount { get; set; }
        public TransferPersonData Sender { get; set; }
        public TransferPersonData Recipient { get; set; }
    }
}