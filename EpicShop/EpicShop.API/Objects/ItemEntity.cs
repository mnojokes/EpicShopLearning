namespace EpicShop.API.Objects;

public class ItemEntity
{
    public int? Id { get; set; } = null;
    public string? Name { get; set; } = null;
    public decimal? Price { get; set; } = null;
    public int? Quantity { get; set; } = null;
}
