namespace CocovoitAPI.Business.Entity;

public class Reservation
{
    public long UtilisateurId { get; set; }
    public Utilisateur Utilisateur { get; set; } = null!;

    public long TrajetId { get; set; }
    public Trajet Trajet { get; set; } = null!;
}

public enum StatutReservation
{
    CONFIRMEE,
    ANNULEE_PAR_PASSAGER,
    ANNULEE_PAR_CONDUCTEUR
}