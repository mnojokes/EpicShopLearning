using EpicShop.Domain.Objects;
using EpicShop.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;

namespace EpicShop.Application.Clients;

public class JsonPlaceholderClient
{
    private readonly HttpClient _httpClient;

    public JsonPlaceholderClient(HttpClient httpClient)
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
        // if user with this id is not found, returns id 0 and empty strings, so no exception is triggered. Switch to using client result object.
        return await response.Content.ReadFromJsonAsync<GetUser>() ?? throw new UserNotFoundException(id.ToString());
    }
}
