namespace Dima.Core.Responses;

public class BaseResponse
{
    private readonly int _code;

    public BaseResponse(string? data, string message, int code)
    {
        Data = data;
        Message = message;
        _code = code;
    }
    
    public string? Data { get; set; }
    public string Message { get; set; } = string.Empty;

    public bool IsSuccess => _code is >= 200 and <= 299; 
}