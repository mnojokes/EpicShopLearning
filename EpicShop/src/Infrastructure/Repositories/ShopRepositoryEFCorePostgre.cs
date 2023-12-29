using Domain.Interfaces;
using Domain.Objects;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class ShopRepositoryEFCorePostgre : IShopRepository
{
    private readonly DataContext _dataContext;

    public ShopRepositoryEFCorePostgre(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int?> Create(ShopEntity shop)
    {
        await _dataContext.Shops.AddAsync(shop);
        _dataContext.SaveChanges();
        return shop.Id;
    }

    public async Task<bool> Delete(int id)
    {
        ShopEntity? ret = _dataContext.Shops.FirstOrDefault(i => i.Id == id);
        if (ret != null)
        {
            _dataContext.Shops.Remove(ret);
            _dataContext.SaveChanges();
            return true;
        }

        return false;
    }

    public async Task<ShopEntity> Get(int id)
    {
        return _dataContext.Shops.FirstOrDefault(i => i.Id == id) ?? new ShopEntity();
    }

    public async Task<IEnumerable<ShopEntity>> Get()
    {
        return _dataContext.Shops.ToList();
    }

    public async Task<bool> Update(ShopEntity shop)
    {
        ShopEntity existing = await Get((int)shop.Id!);
        if (existing.Id != null)
        {
            existing.Name = shop.Name ?? existing.Name;
            existing.Address = shop.Address ?? existing.Address;
            _dataContext.SaveChanges();

            return true;
        }

        return false;
    }
}
