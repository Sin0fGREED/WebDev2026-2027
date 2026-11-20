namespace Hollowmere.Server.DTOs;

public enum DbResult
{
    Success,
    NotFound,
    Concurrency,
    Error,
    Exists
}
