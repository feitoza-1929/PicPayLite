using System.ComponentModel.DataAnnotations;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Presentation.RequestsPattern
{
    public record CreateClientRequest
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Email { get; init; }
        [Required]
        public ClientType Type { get; init; }
        [Required]
        public Document Document { get; init; }
    }
}