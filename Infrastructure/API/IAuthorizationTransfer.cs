namespace PicPayLite.Infrastructure.API
{
    public interface IAuthorizationTransfer
    {
        Task<AuthTransfer> GetAsync();
    }
}