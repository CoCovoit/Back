using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace CocovoitAPI.Domain.models;

public class PointArret
{
    public int Id { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Description { get; set; }

    public int? UtilisateurId { get; set; }
    public Utilisateur Utilisateur { get; set; }

    public ICollection<Trajet> TrajetsDestination { get; set; }
}