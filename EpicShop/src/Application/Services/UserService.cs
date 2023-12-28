﻿using EpicShop.Application.Clients;
using EpicShop.Domain.Objects;

namespace EpicShop.Application.Services;

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
        return await _client.Get();
    }

    public async Task<GetUser> Get(int id)
    {
        return await _client.Get(id);
    }
}
