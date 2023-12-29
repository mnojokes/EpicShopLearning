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

    public async Task Delete(int id)
    {
        if (!await _shopRepository.Delete(id))
        {
            throw new ShopNotFoundException(id.ToString());
        }
    }

    public async Task Update(UpdateShop shop)
    {
        if (!await _shopRepository.Update(shop.ToEntity()))
        {
            throw new ItemNotFoundException(shop.Id.ToString());
        }
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
