using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Domain.Clients
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public ClientType Type { get; private set; }
        public string DocumentValue { get; private set;}
        public DocumentType DocumentType { get; private set; }
        public Account Account { get; private set; }

        private Client(
            string name,
            string email, ClientType type,
            string documentValue,
            DocumentType documentType)
        {
            Name = name;
            Email = email;
            Type = type;
            DocumentValue = documentValue;
            DocumentType = documentType;
        }

        public static Client Create(
            string name,
            string email,
            ClientType type,
            string documentValue,
            DocumentType documentType)
        {
            return new Client(name, email, type, documentValue, documentType);
        }
    }
}

