using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Core.Utilities.Validation;

public static class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        var context = new ValidationContext<object>(entity);
        var result = validator.Validate(context);
        if (!result.IsValid)
        {
            throw new Exception("Not a Validator Type");
        }
    }
}
