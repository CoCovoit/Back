namespace CocovoitAPI.Domain.exception;

public class ReportNotFoundException : Exception
{
    public ReportNotFoundException(string message = "Le compte rendu recherché n'a pas été trouvé.") : base(message) { }
}