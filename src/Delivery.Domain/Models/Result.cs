namespace Delivery.Domain.Models;

public sealed class Result<T>
{
    public T Data { get; init; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    private Result(bool isSuccess, Error error, T data = default!)
    {
        IsSuccess = isSuccess;
        Error = error;
        Data = data;
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(true, Error.None, data);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(false, error);
    }
}
