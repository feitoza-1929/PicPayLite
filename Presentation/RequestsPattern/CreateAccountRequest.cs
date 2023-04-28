using System.ComponentModel.DataAnnotations;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Presentation.RequestsPattern
{
    public record CreateAccountRequest
    {
        [Required]
        public Document Document { get; init; }
    }
}