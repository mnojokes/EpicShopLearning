﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Objects;

public class AddItem
{
    [Required] public string Name { get; set; }
    [Required] public decimal Price { get; set; }
    [Required] public uint Quantity { get; set; }
    public int? ShopId { get; set; } = null;

    public ItemEntity ToEntity()
    {
        return new ItemEntity() { Name = Name, Price = Price, Quantity = (int)Quantity, ShopId = ShopId };
    }
}

public class ItemId
{
    [Required] public int Id { get; set; }
}

public class UpdateItem
{
    [Required] public int Id { get; set; }
    public string? Name { get; set; } = null;
    public decimal? Price { get; set; } = null;
    public uint? Quantity { get; set; } = null;
    public int? ShopId { get; set; } = null;

    public ItemEntity ToEntity()
    {
        return new ItemEntity() { Id = Id, Name = String.IsNullOrEmpty(Name) ? null : Name, Price = Price, Quantity = (int?)Quantity, ShopId = ShopId };
    }
}

public class BuyItem
{
    [Required] public int Id { get; set; }
    [Required] public uint Quantity { get; set; }

    public ItemEntity ToEntity()
    {
        return new ItemEntity() { Id = Id, Quantity = (int)Quantity };
    }
}

public class GetItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public uint Quantity { get; set; }
    public int? ShopId { get; set; } = null;

    public GetItem(ItemEntity item)
    {
        Name = item.Name ?? throw new ArgumentNullException($"{this.GetType()}.Name received a null value");
        Price = item.Price ?? throw new ArgumentNullException($"{this.GetType()}.Price received a null value");
        Quantity = (uint)(item.Quantity ?? throw new ArgumentNullException($"{this.GetType()}.Quantity received a null value"));
        ShopId = item.ShopId;
    }
}
