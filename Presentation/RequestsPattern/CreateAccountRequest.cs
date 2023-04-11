using System.ComponentModel.DataAnnotations;
using PicPayLite.Domain.Clients;

namespace PicPayLite.Presentation.RequestsPattern
{
    public record CreateAccountRequest
    {
        [Required]
        public Guid ClientId { get; init; }
        [Required]
        public Document Document { get; init; }
    }
}