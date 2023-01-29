namespace ProductAPI.Responses;

public abstract class ErrorBase
{
    protected ErrorBase(string code)
    {
        Code = code;
    }

    public string Code { get; set; }
}
