using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using ExtensaoCurricular.Client.Global;

namespace ExtensaoCurricular.Client.Services;

public class BaseServiceAPI<T>
{
    private readonly HttpClient _httpClient;
    private readonly string _uri;
    protected readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public BaseServiceAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration, string customServiceName = null)
    {
        _httpClient = httpClientFactory.CreateClient("WebAPI");
        _uri = customServiceName is null ? typeof(T).Name.ToLower() : customServiceName;
    }

    public async Task<string> GetAsync(params object[] parameters)
    {
        AddHeaders();

        var url = CreateUrl(parameters);
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();

        return null;
    }

    public async Task<string> GetWithCancellationTokenAsync(CancellationToken cancellationToken, params object[] parameters)
    {
        AddHeaders();

        var url = CreateUrl(parameters);
        var response = await _httpClient.GetAsync(url, cancellationToken);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();

        return null;
    }

    public async Task<string> PostAsync(object obj, params object[] parameters)
    {
        AddHeaders();

        var url = CreateUrl(parameters);
        var serializedObject = JsonSerializer.Serialize(obj);
        var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();

        return null;
    }

    public async Task<string> PutAsync(object obj, params object[] parameters)
    {
        AddHeaders();

        var url = CreateUrl(parameters);
        var serializedObject = JsonSerializer.Serialize(obj);
        var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync(url, content);

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> DeleteAsync(params object[] parameters)
    {
        AddHeaders();

        var url = CreateUrl(parameters);
        var response = await _httpClient.DeleteAsync(url);

        return await response.Content.ReadAsStringAsync();
    }

    private string CreateUrl(params object[] parameters)
    {
        return $"{_uri}/{string.Join("/", parameters)}";
    }

    private void AddHeaders()
    {
        if (GlobalValues.UserInfo is null) return;

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalValues.UserInfo.Token);
    }
}