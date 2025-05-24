namespace CocovoitAPI.Business.Entity;

public class Trajet
{
    public long Id { get; set; }

    public long ConducteurId { get; set; }
    public Utilisateur Conducteur { get; set; } = null!;

    public long LocalisationDepartId { get; set; }
    public Localisation LocalisationDepart { get; set; } = null!;

    public long LocalisationArriveeId { get; set; }
    public Localisation LocalisationArrivee { get; set; } = null!;

    public DateTime DateHeure { get; set; }
    public int NombrePlaces { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}