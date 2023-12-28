using System.ComponentModel.DataAnnotations;

namespace Domain.Objects;

public class CreateShop
{
    [Required] public string Name { get; set; }
    [Required] public string Address { get; set; }
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
}
