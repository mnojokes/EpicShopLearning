namespace Domain.Objects;

public class JsonPlaceholderResult<T> where T : class
{
    public bool IsSuccess
    {
        get
        {
            return Data is not null && Error is null;
        }
    }

    public ErrorMessage? Error { get; set; } = null;
    public T? Data { get; set; } = null;
}
