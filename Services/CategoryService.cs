using System.Text.Json;
using pedals_ui.Models;

using pedals_ui.Services;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;
    private readonly ILogger<CategoryService> _logger;
    public CategoryService(HttpClient httpClient, ILogger<CategoryService> logger)
    {
        _httpClient = httpClient;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _logger = logger;
    }
    public async Task<List<Category>?> GetCategories()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/category");
            var content = await response.Content.ReadAsStringAsync();
            _logger.LogInformation(content);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Category>>(content, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new();
        }
    }
}
