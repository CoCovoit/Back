namespace CocovoitAPI.Domain.exception;

public class FolderNotEmptyException : Exception
{
    public FolderNotEmptyException(string message = "Le dossier n'est pas vide.") : base(message) { }
}