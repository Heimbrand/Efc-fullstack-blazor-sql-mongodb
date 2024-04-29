using Labb2WebbTemplate.Common.Dtos;
using Labb2WebbTemplate.Common.Interfaces;

namespace webbutveckling_labb2_Heimbrand.Client.AuthApi.Services;

public class CategoryService : ICategoryService<CategoryDto>
{
    private readonly HttpClient _httpClient;
    public CategoryService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Labb2WebbOlleDb");
    }
    public async Task AddCategory(CategoryDto category)
    {
        var response = await _httpClient.PostAsJsonAsync("api/category", category);

        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }
    public async Task DeleteCategory(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/category/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return;
        }

    }
    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
    {
        var response = await _httpClient.GetAsync("api/category");
        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<CategoryDto>();
        }
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<CategoryDto>>();
        return result ?? Enumerable.Empty<CategoryDto>();
    }
    public async Task<CategoryDto?> GetCategoryByName(string name)
    {
        var response = await _httpClient.GetAsync($"api/category/{name}");

        var result = await response.Content.ReadFromJsonAsync<CategoryDto>();
        return result;
    }
    public async Task UpdateCategory(CategoryDto category)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/category/{category.Id}", category);
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }
}