using ExtensaoCurricular.Client.Services.Interfaces;
using ExtensaoCurricular.Shared.Dtos.General;
using ExtensaoCurricular.Shared.Extensions;
using System.Text.Json;

namespace ExtensaoCurricular.Client.Services;

public class BaseService<T> : BaseServiceAPI<T>, IBaseService<T> where T : class
{
    public BaseService(IHttpClientFactory httpClientFactory, IConfiguration configuration, string customServiceName = null) : base(httpClientFactory, configuration, customServiceName)
    {
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var content = await GetAsync(id);
        return Deserialize<T>(content);
    }

    public async Task<bool> CreateAsync(T obj)
    {
        var content = await PostAsync(obj);
        return Deserialize<bool>(content);
    }

    public async Task<bool> UpdateAsync(T obj)
    {
        var content = await PutAsync(obj);
        return Deserialize<bool>(content);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var content = await base.DeleteAsync(id);
        return Deserialize<bool>(content);
    }

    protected K Deserialize<K>(string json)
    {
        if (json.IsNullOrEmpty()) return default;

        return JsonSerializer.Deserialize<K>(json, _options);
    }
}