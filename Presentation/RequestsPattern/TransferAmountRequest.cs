using System.ComponentModel.DataAnnotations;
using PicPayLite.Domain.Tranfers;

namespace PicPayLite.Presentation.RequestsPattern
{ 
    public record TransferAmountRequest
    {
        [Required]
        public int Amount { get; init; }
        [Required]
        public Sender Sender { get; init; }
        [Required]
        public Recipient Recipient { get; init; }
    }
}