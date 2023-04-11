namespace PicPayLite.Infrastructure.API
{
    public interface IAuthorizationTransfer
    {
        Task<AuthData> GetAsync();
    }
}