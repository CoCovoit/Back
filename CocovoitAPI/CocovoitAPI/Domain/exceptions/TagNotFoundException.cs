namespace CocovoitAPI.Domain.exception;

public class TagNotFoundException : Exception
{
    public TagNotFoundException(string message = "Le tag recherché n'a pas été trouvé.") : base(message) { }
}