using Application.Clients;
using Domain.Exceptions;
using Domain.Objects;

namespace Application.Services;

public class UserService
{
    private readonly JsonPlaceholderClient _client;

    public UserService(JsonPlaceholderClient client)
    {
        _client = client;
    }
    public async Task<string> Add(CreateUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<List<GetUser>> Get()
    {
        JsonPlaceholderResultList<GetUser> result = await _client.Get();
        if (!result.IsSuccess)
        {
            throw new UserNotFoundException(result.Error!.Message!);
        }

        return result.Data!;
    }

    public async Task<GetUser> Get(int id)
    {
        JsonPlaceholderResult<GetUser> result = await _client.Get(id);
        if (!result.IsSuccess)
        {
            throw new UserNotFoundException(result.Error!.Message!);
        }

        return result.Data!;
    }
}
