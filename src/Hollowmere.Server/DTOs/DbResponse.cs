namespace Hollowmere.Server.DTOs;

public class DbResponse<T>(DbResult result, T? data = default)
{
    public DbResult Result { get; set; } = result;
    public T? Data { get; set; } = data;

    public static DbResponse<T> Success(T? data) => new(DbResult.Success, data);
    public static DbResponse<T> NotFound() => new(DbResult.NotFound, default);
    public static DbResponse<T> Exists() => new(DbResult.Exists, default);
    public static DbResponse<T> Concurrency() => new(DbResult.Concurrency, default);
    public static DbResponse<T> Error() => new(DbResult.Error, default);
}
