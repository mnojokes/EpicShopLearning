using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Domain.Objects;

public class CreateShop
{
    [Required] public string Name { get; set; }
    [Required] public string Address { get; set; }

    public ShopEntity ToEntity()
    {
        return new ShopEntity()
        {
            Name = Name,
            Address = Address
        };
    }
}

public class ShopId
{
    [Required] public int Id { get; set; }
}

public class UpdateShop
{
    [Required] public int Id { get; set; }
    public string? Name { get; set; } = null;
    public string? Address { get; set; } = null;

    public ShopEntity ToEntity()
    {
        return new ShopEntity()
        {
            Id = Id,
            Name = Name,
            Address = Address
        };
    }
}

public class DeleteShop
{
    [Required] public int Id { get; set; }
}

public class GetShop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public GetShop(ShopEntity shop)
    {
        Name = shop.Name ?? throw new ArgumentNullException($"{this.GetType()}.Name received a null value");
        Address = shop.Address ?? throw new ArgumentNullException($"{this.GetType()}.Address received a null value");
    }
}
