namespace Domain.Objects;

public class JsonPlaceholderResult<Type> where Type : class
{
    public bool IsSuccess
    {
        get
        {
            return Data is not null && Error is null;
        }
    }

    public ErrorMessage? Error { get; set; } = null;
    public Type? Data { get; set; } = null;
}
