using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics;

namespace CocovoitAPI.Business.Entity;

public class Utilisateur
{
    public long Id { get; set; }
    
    public string Nom { get; set; } = string.Empty;
    
    public required string Email { get; set; }

    public long? LocalisationId { get; set; }
    public Localisation? Localisation { get; set; }

    public ICollection<Trajet> TrajetsEnTantQueConducteur { get; set; } = new List<Trajet>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}


public class Localisation
{
    public Localisation(string adresse, double longitude, double latitude)
    {
        Adresse = adresse;
        Longitude = longitude;
        Latitude = latitude;
    }

    public long Id { get; set; }
    public string Adresse { get; set; } = string.Empty;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}
