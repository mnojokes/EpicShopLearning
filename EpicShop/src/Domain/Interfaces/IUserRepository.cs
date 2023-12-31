﻿using Domain.Objects;

namespace Domain.Interfaces;

public interface IUserRepository
{
    public Task<int?> Create(UserEntity user);
    public Task<IEnumerable<UserEntity>> Get();
    public Task<UserEntity> Get(int id);
}
