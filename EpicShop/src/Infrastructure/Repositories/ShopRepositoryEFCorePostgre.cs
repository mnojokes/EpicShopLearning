using Domain.Interfaces;
using Domain.Objects;

namespace Infrastructure.Repositories;

public class ShopRepositoryEFCorePostgre : IShopRepository
{
    public async Task<int?> Create(ShopEntity shop)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ShopEntity> Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ShopEntity>> Get()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(ShopEntity shop)
    {
        throw new NotImplementedException();
    }
}
