namespace ProductAPI.Responses;

public class ErrorDetail : ErrorBase
{
    protected ErrorDetail(string code) : base(code)
    {
    }

    public ErrorDetail(string code, string message, string? target = null) : base(code)
    {
        Message = message;
        Target = target;
    }

    public string? Message { get; set; }

    public string? Target { get; set; }
}
