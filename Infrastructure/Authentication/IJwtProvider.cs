using PicPayLite.Domain.Clients;

namespace PicPayLite.Infrastructure.Authentication
{
    public interface IJwtProvider
    {
        string Generate(Client client);
    }
}