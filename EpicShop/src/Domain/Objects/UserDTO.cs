using System.ComponentModel.DataAnnotations;

namespace Domain.Objects;

public class CreateUser
{
    [Required] public string Name { get; set; }
    [Required] public string Username { get; set; }
    [Required] public string Email { get; set; }
    public string Website { get; set; } = string.Empty;
}

public class GetUser
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string Username { get; set; } = string.Empty;
    [Required] public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
}
