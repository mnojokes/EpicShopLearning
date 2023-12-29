using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Objects;
using System.Text.Json;

namespace Application.Services;

public class ItemService
{
    private readonly IItemRepository _itemRepository;
    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    } 
    public async Task<string> Add(AddItem item)
    {
        int id = await _itemRepository.Add(item.ToEntity()) ?? throw new InvalidOperationException("Unable to add item");
        return JsonSerializer.Serialize(new { id = id.ToString() });
    }

    public async Task<GetItem> Buy(BuyItem item)
    {
        try
        {
            GetItem bought = new GetItem(await _itemRepository.Buy(item.ToEntity()));
            switch (bought.Quantity)
            {
                case > 20:
                    bought.Price *= 0.8m;
                    break;
                case > 10:
                    bought.Price *= 0.9m;
                    break;
                default:
                    break;
            }
            return bought;
        }
        catch (ArgumentNullException)
        {
            throw new ItemNotFoundException(item.Id.ToString());
        }
    }

    public async Task Delete(int id)
    {
        if (!await _itemRepository.Delete(id))
        {
            throw new ItemNotFoundException(id.ToString());
        }
    }

    public async Task<List<GetItem>> Get()
    {
        var list = await _itemRepository.Get();
        return list.Select(i => new GetItem(i)).ToList();
    }

    public async Task<GetItem> Get(int id)
    {
        try
        {
            return new GetItem(await _itemRepository.Get(id));
        }
        catch (ArgumentNullException)
        {
            throw new ItemNotFoundException(id.ToString());
        }
    }

    public async Task Update(UpdateItem item)
    {
        if (!await _itemRepository.Update(item.ToEntity()))
        {
            throw new ItemNotFoundException(item.Id.ToString());
        }
    }

    //public async Task AssignShop(int itemId, int shopId)
    //{
    //    await Update(new UpdateItem() { Id = itemId, ShopId = shopId });
    //}
}
