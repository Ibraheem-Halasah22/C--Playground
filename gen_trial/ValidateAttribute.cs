namespace gen_trial;

public class ValidateAttribute : System.Attribute
{
    private List<IValidator> _validators = new();
    
}