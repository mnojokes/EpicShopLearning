namespace Domain.Objects;

public class JsonPlaceholderResultList<T> where T : class
{
    public bool IsSuccess
    {
        get
        {
            return Data is not null && Error is null;
        }
    }

    public ErrorMessage? Error { get; set; } = null;
    public List<T>? Data { get; set; } = null;
}
