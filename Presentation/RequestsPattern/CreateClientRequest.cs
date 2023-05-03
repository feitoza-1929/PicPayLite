using System.ComponentModel.DataAnnotations;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Presentation.RequestsPattern
{
    public record CreateClientRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; init; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; init; }

        [Required]
        public ClientType Type { get; init; }

        [Required]
        public Document Document { get; init; }
    }
}