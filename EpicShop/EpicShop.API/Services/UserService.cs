using EpicShop.API.Clients;
using EpicShop.API.Objects;

namespace EpicShop.API.Services;

public class UserService
{
    private readonly JsonClient _client;

    public UserService(JsonClient client)
    {
        _client = client;
    }
    public async Task<string> Add(CreateUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<List<GetUser>> Get()
    {
        return await _client.Get();
    }

    public async Task<GetUser> Get(int id)
    {
        return await _client.Get(id);
    }
}
