namespace Domain.Objects;

public class JsonPlaceholderResultList<Type> where Type : class
{
    public bool IsSuccess
    {
        get
        {
            return Data is not null && Error is null;
        }
    }

    public ErrorMessage? Error { get; set; } = null;
    public List<Type>? Data { get; set; } = null;
}
