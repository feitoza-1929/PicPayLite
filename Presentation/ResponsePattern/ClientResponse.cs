using PicPayLite.Domain.Clients;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Presentation.ResponsePattern
{
    public class ClientResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public ClientType Type { get; private set; }
        public Document Document { get; private set; }

        private ClientResponse(
            Guid id,
            string name,
            string email, ClientType type,
            string documentValue,
            DocumentType documentType)
        {
            Id = id;
            Name = name;
            Email = email;
            Type = type;
            Document = new(documentType, documentValue);
           
        }

        public static ClientResponse Create(Client client)
        {
            return new ClientResponse(
                client.Id,
                client.Name, 
                client.Email, 
                client.Type, 
                client.DocumentValue, 
                client.DocumentType);
        }
    }
}