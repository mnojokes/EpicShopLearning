using EpicShop.API.Objects;
using EpicShop.API.Exceptions;
using System.Linq;

namespace EpicShop.API.Clients;

public class JsonClient
{
    private readonly HttpClient _httpClient;

    public JsonClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<GetUser>> Get()
    {
        var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
        if (!response.IsSuccessStatusCode)
        {
            // TODO: should not throw exceptions. Switch to client result object
            throw new BadHttpRequestException("Cannot access user data.");
        }
        return await response.Content.ReadFromJsonAsync<List<GetUser>>() ?? new List<GetUser>();
    }

    public async Task<GetUser> Get(int id)
    {
        var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{id}");
        return await response.Content.ReadFromJsonAsync<GetUser>() ?? throw new UserNotFoundException(id.ToString());
    }
}
