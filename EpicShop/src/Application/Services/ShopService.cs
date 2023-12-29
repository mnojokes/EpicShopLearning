using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Objects;
using System.Text.Json;

namespace Application.Services;

public class ShopService
{
    private readonly IShopRepository _shopRepository;
    public ShopService(IShopRepository shopRepository)
    {
        _shopRepository = shopRepository;
    }

    public async Task<string> Create(CreateShop shop)
    {
        return JsonSerializer.Serialize(new { id = await _shopRepository.Create(shop.ToEntity()) });
    }

    public async Task<bool> Delete(int id)
    {
        return await _shopRepository.Delete(id);
    }

    public async Task<bool> Update(UpdateShop shop)
    {
        return await _shopRepository.Update(shop.ToEntity());
    }

    public async Task<GetShop> Get(int id)
    {
        try
        {
            return new GetShop(await _shopRepository.Get(id));
        }
        catch (ArgumentNullException)
        {
            throw new ShopNotFoundException(id.ToString());
        }
    }

    public async Task<List<GetShop>> Get()
    {
        var list = await _shopRepository.Get();
        return list.Select(s => new GetShop(s)).ToList();
    }
}
