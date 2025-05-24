using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics;

namespace CocovoitAPI.Domain.models;

public class Utilisateur
{
    public long Id { get; set; }
    public string Nom { get; set; } = string.Empty;

    public long? LocalisationId { get; set; }
    public Localisation? Localisation { get; set; }

    public ICollection<Trajet> TrajetsEnTantQueConducteur { get; set; } = new List<Trajet>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}


public class Localisation
{
    public long Id { get; set; }
    public string Adresse { get; set; } = string.Empty;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}

/*
public enum Role
{
    STANDARD,
    ADMIN_RH
}

public enum RoleDansTrajet
{
    CONDUCTEUR,
    PASSAGER
}
*/