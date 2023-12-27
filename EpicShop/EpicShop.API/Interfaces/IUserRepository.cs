using EpicShop.API.Objects;
using Microsoft.AspNetCore.SignalR;

namespace EpicShop.API.Interfaces;

public interface IUserRepository
{
    public Task<int?> Create(UserEntity user);
    public Task<IEnumerable<UserEntity>> Get();
    public Task<UserEntity> Get(int id);
}
