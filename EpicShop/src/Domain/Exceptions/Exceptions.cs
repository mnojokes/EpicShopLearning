namespace Domain.Exceptions;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException() { }
    public ItemNotFoundException(string itemId) : base($"Item id {itemId} not found") { }
}

public class UserNotFoundException : Exception
{
    public UserNotFoundException() { }
    public UserNotFoundException(string userId) : base($"User id {userId} not found") { }
}

public class ShopNotFoundException : Exception
{
    public ShopNotFoundException() { }
    public ShopNotFoundException(string shopId) : base($"Shop id {shopId} not found") { }
}
