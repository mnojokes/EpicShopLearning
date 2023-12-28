using Domain.Objects;

namespace Domain.Interfaces;

public interface IItemRepository
{
    public Task<int?> Add(ItemEntity item);
    public Task<bool> Delete(int id);
    public Task<bool> Update(ItemEntity item);
    public Task<ItemEntity> Get(int id);
    public Task<IEnumerable<ItemEntity>> Get();
    public Task<ItemEntity> Buy(ItemEntity item);
}
