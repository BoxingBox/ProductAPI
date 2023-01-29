namespace ProductAPI.Responses;

public class Error : InnerError
{
    public Error(string code) : base(code)
    {
    }

    public Error(string code, string message) : base(code, message)
    {
    }

    public Error(string code, string message, InnerError innerError) : base(code, message, innerError)
    {
    }

    public List<ErrorDetail> Details { get; } = new();
}
