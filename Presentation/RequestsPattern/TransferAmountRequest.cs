using System.ComponentModel.DataAnnotations;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Presentation.RequestsPattern
{
    public class TransferAmountRequest
    {
        [Required]
        public int Amount { get; set; }
        [Required]
        public TransferPersonData Sender { get; set; }
        [Required]
        public TransferPersonData Recipient { get; set; }
    }
}