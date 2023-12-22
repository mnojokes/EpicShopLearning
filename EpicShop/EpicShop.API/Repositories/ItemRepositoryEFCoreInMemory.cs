using EpicShop.API.Contexts;
using EpicShop.API.Interfaces;
using EpicShop.API.Objects;

namespace EpicShop.API.Repositories;

public class ItemRepositoryEFCoreInMemory : IItemRepository
{
    private readonly DataContext _dataContext;

    public ItemRepositoryEFCoreInMemory(DataContext dataContext)
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
        _dataContext.Items.Update(item);
        _dataContext.SaveChanges();
        return true;
    }
}
