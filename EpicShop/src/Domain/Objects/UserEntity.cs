namespace EpicShop.Domain.Objects;

public class UserEntity
{
    public int? Id { get; set; } = null;
    public string Name { get; set; } = string.Empty;
    public string Username {  get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
}
