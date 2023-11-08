using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace gen_trial;

using System;

public abstract class IValidator : ValidationAttribute
{
    public string Name { get; init; }
    protected abstract override ValidationResult IsValid(object? value, ValidationContext validationContext);
}

public class MinLengthValidator : IValidator
{
    public int n { get; set; }

    public int MinLength { get; init; }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string str || str.Length < n)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}

public class MaxLengthValidator : IValidator
{
    public int n { get; set; }

    public int MinLength { get; init; }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string str || str.Length > n)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}

public class CustomClass
{
    [MinLengthValidator(n = 10, Name = "My name")]
    [MaxLengthValidator(n = 20, Name = "My name")]

    public string ClassNm { get; set; }

    public static void PrintValidators()
    {
        Type type = typeof(CustomClass);
        PropertyInfo[] properties = type.GetProperties();

        Dictionary<string, string> validationInfo = new Dictionary<string, string>();
        var i = 0;
        foreach (var property in properties)
        {
            var ValidationAttributes = property.GetCustomAttributes(typeof(IValidator), true);


            foreach (var validator in ValidationAttributes.Cast<IValidator>())
            {
            validationInfo.Add(validator.Name + i++, $"Its a validator {validator.GetType().FullName}");
            }

        }

        foreach (var info in validationInfo)
        {
            Console.WriteLine($"Field Name: {info.Key}, Validation Information: {info.Value}");
        }
    }
}

public class Runner
{
    public static void Main()
    {
        var cc = new CustomClass();
        cc.ClassNm = "He ";
        var context = new ValidationContext(cc);
        var results = new System.Collections.Generic.List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(cc, context, results, true);

        if (!isValid)
        {
            foreach (var validationResult in results)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }
        }

        CustomClass.PrintValidators();
    }
}