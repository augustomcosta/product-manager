namespace Product_Manager.Domain.Validation;

public class DomainValidationException : Exception
{
    private DomainValidationException(string error) : base(error)
    {
        
    }

    public static void When(bool hasError, string error)
    {
        if (hasError)
        {
            throw new DomainValidationException(error);
        }
    }
}