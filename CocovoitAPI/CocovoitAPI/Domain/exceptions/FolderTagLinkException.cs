namespace CocovoitAPI.Domain.exception;

public class FolderTagLinkException : Exception
{
    public FolderTagLinkException(string message = "Impossible de lier le tag au dossier") : base(message) { }
}