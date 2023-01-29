using ProductAPI.Responses;

namespace ProductAPI.Extensions;

public static class ErrorDetailExtensions
{
    public static Error ToError(this IEnumerable<ErrorDetail> errors, string code, string message)
    {
        Error error = new(code, message);
        error.Details.AddRange(errors);

        return error;
    }


}
