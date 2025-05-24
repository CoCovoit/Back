namespace CocovoitAPI.Domain.exception;

public class FolderTagNotFoundException : Exception
{
    public FolderTagNotFoundException(string message = "Aucune liaison existe entre le dossier et le tag.") : base(message) { }
}