using Domain.Objects;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;


namespace Application.Clients;

public class JsonPlaceholderClient
{
    private readonly HttpClient _httpClient;
    public JsonPlaceholderClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<JsonPlaceholderResult<GetUser>> Add(CreateUser user)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("https://jsonplaceholder.typicode.com/posts", user);
        JsonPlaceholderResult<GetUser> result = new JsonPlaceholderResult<GetUser>();
        switch (response.IsSuccessStatusCode)
        {
            case true:
                result.Data = await response.Content.ReadFromJsonAsync<GetUser>();
                break;
            case false:
                result.Error = new ErrorMessage() { Message = $"Cannot create user. Error {(int)response.StatusCode}", Code = (int)response.StatusCode };
                break;
        }

        return result;
    }

    public async Task<JsonPlaceholderResultList<GetUser>> Get()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
        JsonPlaceholderResultList<GetUser> result = new JsonPlaceholderResultList<GetUser>();
        switch (response.IsSuccessStatusCode)
        {
            case true:
                result.Data = await response.Content.ReadFromJsonAsync<List<GetUser>>();
                if (result.Data == null)
                {
                    result.Error = new ErrorMessage() { Message = $"Error getting all users", Code = (int)response.StatusCode };
                }
                break;
            case false:
                result.Error = new ErrorMessage() { Message = $"Cannot get users. Error {(int)response.StatusCode}", Code = (int)response.StatusCode };
                break;
        }

        return result;
    }

    public async Task<JsonPlaceholderResult<GetUser>> Get(int id)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{id}");
        JsonPlaceholderResult<GetUser> result = new JsonPlaceholderResult<GetUser>();
        switch (response.IsSuccessStatusCode)
        {
            case true:
                result.Data = await response.Content.ReadFromJsonAsync<GetUser>();
                if (result.Data == null || result.Data.Id == 0)
                {
                    result.Data = null;
                    result.Error = new ErrorMessage() { Message = $"Cannot get user with id {id}", Code = (int)response.StatusCode };
                }
                break;
            case false:
                result.Error = new ErrorMessage() { Message = $"Cannot connect to service. Error {(int)response.StatusCode}", Code = (int)response.StatusCode };
                break;
        }

        return result;
    }
}
