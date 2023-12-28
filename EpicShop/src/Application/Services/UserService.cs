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
    public async Task<GetUser> Add(CreateUser user)
    {
        var result = await _client.Add(user);
        if (!result.IsSuccess)
        {
            throw new ApplicationException(result.Error!.Message!);
        }

        return result.Data!;
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
