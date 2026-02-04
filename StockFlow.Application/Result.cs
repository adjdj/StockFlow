/*!
 * @file Result.cs
 * @brief 
 * @author -
 * @copyright -
 * @details
 * 
 */
namespace StockFlow.Application;

public class Result {
    public bool IsSuccess { get; }
    public string? Error { get; }
    public ResultType Type { get; }

    private Result(bool success, ResultType type, string? error = null) {
        IsSuccess = success;
        Type = type;
        Error = error;
    }

    public static Result Success() => new(true, ResultType.Success);
    public static Result Fail(string error) => new(false, ResultType.BadRequest, error);
    public static Result NotFound(string error) => new(false, ResultType.NotFound, error);
    public static Result Conflict(string error) => new(false, ResultType.Conflict, error);

    public enum ResultType {
        Success,
        BadRequest,
        NotFound,
        Conflict
    }

}