namespace CadastralBuildingInfo.Abstractions;

public class Result<T>
{
    public T Value { get; private set; }
    public ErrorDetails Error {  get; private set; } 
    public bool IsSucces { get; private set; }

    private Result(T value, ErrorDetails error, bool isSucces)
    {
        if (isSucces && error != ErrorDetails.None
            || !isSucces && error == ErrorDetails.None)
        {
            throw new ArgumentException($"Invalid object {nameof(Result<T>)}");
        }
        Value = value;
        Error = error;
        IsSucces = isSucces;
    }

    public static Result<T> Succes(T value) => new(value, ErrorDetails.None, true);
    public static Result<T> Failure(ErrorDetails error) => new(default, error, false);
}
