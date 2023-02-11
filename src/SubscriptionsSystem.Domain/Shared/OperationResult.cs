namespace SubscriptionsSystem.Domain.Shared;

public class OperationResult<TResult>
{
    private OperationResult()
    {
    }

    public bool IsSuccess { get; private init; }
    public bool IsFailed => !IsSuccess;
    public TResult? Data { get; private init; }

    public ErrorDto? Error { get; private init; }

    public static OperationResult<TResult> Success(TResult? data)
        => new() { IsSuccess = true, Data = data };

    public static OperationResult<TResult> Failed(Enum error)
        => new() { IsSuccess = false, Error = error };

    public static implicit operator OperationResult<TResult>(ErrorDto error) =>
        new() { IsSuccess = false, Error = error };

    public static implicit operator OperationResult<TResult>(Enum error) =>
        Failed(error);

    public static implicit operator OperationResult<TResult>(TResult data) =>
        Success(data);
}