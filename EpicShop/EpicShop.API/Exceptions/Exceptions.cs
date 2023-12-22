namespace EpicShop.API.Exceptions;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException() { }
    public ItemNotFoundException(string itemId) : base($"Item id {itemId} not found") { }
}
