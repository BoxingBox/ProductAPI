namespace ProductAPI.Responses;

public class InnerError : ErrorDetail
{
    protected InnerError(string code) : base(code)
    {
    }

    protected InnerError(string code, string message, InnerError? internalError = null) : base(code, message)
    {
        InternalError = internalError;
    }

    public InnerError? InternalError { get; set; }
}
