using Infrastructure.Contexts;
using Domain.Interfaces;
using Domain.Objects;

namespace Infrastructure.Repositories;

public class ItemRepositoryEFCorePostgre : IItemRepository
{
    private readonly DataContext _dataContext;

    public ItemRepositoryEFCorePostgre(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<int?> Add(ItemEntity item)
    {
        await _dataContext.Items.AddAsync(item);
        _dataContext.SaveChanges();
        return item.Id;
    }

    public async Task<ItemEntity> Buy(ItemEntity item)
    {
        ItemEntity? ret = _dataContext.Items.FirstOrDefault(i => i.Id == item.Id);
        if (ret == null) { return new ItemEntity(); }
        ret.Quantity = item.Quantity;
        return ret;
    }

    public async Task<bool> Delete(int id)
    {
        ItemEntity? ret = _dataContext.Items.FirstOrDefault(i => i.Id == id);
        if (ret != null)
        { 
            _dataContext.Items.Remove(ret);
            _dataContext.SaveChanges();
            return true;
        }

        return false;
    }

    public async Task<ItemEntity> Get(int id)
    {
        return _dataContext.Items.FirstOrDefault(i => i.Id == id) ?? new ItemEntity();
    }

    public async Task<IEnumerable<ItemEntity>> Get()
    {
        return _dataContext.Items.ToList();
    }

    public async Task<bool> Update(ItemEntity item)
    {
        ItemEntity existing = await Get((int)item.Id!);
        if (existing.Id != null)
        {
            existing.Name = item.Name ?? existing.Name;
            existing.Price = item.Price ?? existing.Price;
            existing.Quantity = item.Quantity ?? existing.Quantity;
            existing.ShopId = item.ShopId ?? existing.ShopId;
            _dataContext.SaveChanges();

            return true;
        }

        return false;
    }
}
