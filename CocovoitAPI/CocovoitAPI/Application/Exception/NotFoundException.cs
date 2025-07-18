namespace CocovoitAPI.Application.Exception;

public class LocalisationNotFoundException : KeyNotFoundException
{
    public LocalisationNotFoundException(long id) : base($"La localisation possédant l'id : {id} n'a pas été trouvé.") { }
}

public class UtilisateurNotFoundException : KeyNotFoundException
{
    public UtilisateurNotFoundException(long id) : base($"L'utilisateur possédant l'id : {id} n'a pas été trouvé.") { }
}

public class TrajetNotFoundException : KeyNotFoundException
{
    public TrajetNotFoundException(long id) : base($"Le trajet possédant l'id : {id} n'a pas été trouvé.") { }
}