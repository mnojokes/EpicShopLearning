using Domain.Objects;

namespace Domain.Interfaces;

public interface IShopRepository
{
    public Task<int?> Create(ShopEntity shop);
    public Task<bool> Delete(int id);
    public Task<bool> Update(ShopEntity shop);
    public Task<ShopEntity> Get(int id);
    public Task<IEnumerable<ShopEntity>> Get();
}
