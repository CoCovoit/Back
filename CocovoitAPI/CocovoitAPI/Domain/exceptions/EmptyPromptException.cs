namespace CocovoitAPI.Domain.exception;

public class EmptyPromptException : Exception
{
    public EmptyPromptException(string message = "La chaine de prompt est vide.") : base(message) { }
}