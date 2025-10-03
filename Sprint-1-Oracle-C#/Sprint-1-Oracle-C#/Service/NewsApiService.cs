namespace Sprint_1_Oracle_C_.Service;

public class NewsApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public NewsApiService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _apiKey = config["NewsApi:ApiKey"];
        _httpClient.BaseAddress = new Uri("https://newsapi.org/v2/");
        httpClient.DefaultRequestHeaders.Add("User-Agent", "MyNewsApp/1.0");
    }

    public async Task<string> GetTopHeadlinesAsync()
    {
        var response = await _httpClient.GetAsync($"top-headlines?country=us&apiKey={_apiKey}");
        return await response.Content.ReadAsStringAsync();
    }
}
