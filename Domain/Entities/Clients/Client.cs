namespace PicPayLite.Domain.Clients
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public ClientType Type { get; private set; }
        public Document Document { get; private set; }

        private Client(
            string name, 
            string email, 
            ClientType type, 
            Document document)
        {
            Id = new Guid();
            Name = name;
            Email = email;
            Type = type;
            Document = document;
        }

        public static Client Create(
            string name,
            string email,
            ClientType type,
            Document document)
        {
            return new Client(name, email, type, document);
        }
    }
}

