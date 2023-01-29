using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProductAPI.Responses;

namespace ProductAPI.Extensions;

public static class ModelStateDictionaryExtensions
{
    public static IEnumerable<ErrorDetail> ToErrorDetails(this ModelStateDictionary modelState)
    {
        IEnumerable<ErrorDetail> errors = modelState.Select(modelStateEntry =>
        {
            (string key, ModelStateEntry? value) = modelStateEntry;
            return value?.Errors.Select(modelError =>
                new ErrorDetail("ValidationFailure", modelError.ErrorMessage, key));
        }).SelectMany(s => s ?? Array.Empty<ErrorDetail>());

        return errors;
    }

    public static Error ToValidationError(this ModelStateDictionary modelState)
    {
        var errors = modelState.ToErrorDetails();
        Error error = new("ValidationFailure", "Invalid model");
        error.Details.AddRange(errors);

        return error;
    }
}
