namespace CocovoitAPI.Domain.exception;

public class FolderNotFoundException : Exception
{
    public FolderNotFoundException(string message = "Le dossier recherché n'a pas été trouvé.") : base(message) { }
}