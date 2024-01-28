using System.Text.Json;
using VirtualShop.Web.Models;
using VirtualShop.Web.Services.Contracts;

namespace VirtualShop.Web.Services;

public class CategoryService : ICategoryService
{
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly JsonSerializerOptions _jsonSerializerOptions;
	const string apiEndpoint = "/api/categories/";

	public CategoryService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
		_jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
	}

	public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
	{
		IEnumerable<CategoryViewModel> categories;

		var client = _httpClientFactory.CreateClient("ProductApi");
		var response = await client.GetAsync(apiEndpoint);

		if (response.IsSuccessStatusCode)
		{
			var apiResponse = await response.Content.ReadAsStreamAsync();
			categories = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _jsonSerializerOptions);
		}
		else
			return null;

		return categories;
	}
}