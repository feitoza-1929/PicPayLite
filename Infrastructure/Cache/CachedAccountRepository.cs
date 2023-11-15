using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.Repositories;

namespace PicPayLite.Infrastructure.Cache;

public class CachedAccountRepository
{
    private readonly IAccountRepository _repository;
    private readonly IDistributedCache _cache;

    public CachedAccountRepository(IAccountRepository repository, IDistributedCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<Account> GetAccountById(Guid id)
    {
        return await CacheProcess(() => _repository.GetAccountById(id), id);
    }

    public async Task<Account> GetAccountByNumber(int number)
    {
        return await CacheProcess(() => _repository.GetAccountByNumber(number), number);
    }

    public async Task<Account> GetAccountByClientId(Guid id)
    {
        return await CacheProcess(() => _repository.GetAccountByClientId(id), id);
    }

    public async Task<bool> AnyAccountByClientId(Guid id)
    {
        return await _repository.AnyAccountByClientId(id);
    }

    public async Task<bool> AnyAccountNumber(int number)
    {
        return await _repository.AnyAccountNumber(number);
    }

    private async Task<Account> CacheProcess(Func<Task<Account>> getMethod, object id)
    {
        var cachedItemKey = $"item-{id}";
        var cachedItem = await _cache.GetStringAsync(cachedItemKey);

        if (string.IsNullOrEmpty(cachedItem))
        {
            var account = await getMethod();

            if (account is null)
                return account;

            await _cache.SetStringAsync(cachedItemKey, JsonConvert.SerializeObject(account));
            return account;
        }

        return JsonConvert.DeserializeObject<Account>(cachedItem);
    }

}