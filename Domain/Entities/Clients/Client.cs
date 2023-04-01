namespace PicPayLite.Domain.Clients
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public ClientType Type { get; private set; }
        public Document Document { get; private set; }
    }
}

