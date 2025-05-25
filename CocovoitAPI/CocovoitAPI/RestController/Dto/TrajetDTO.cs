namespace CocovoitAPI.RestController.Dto;

public class TrajetRequestDTO
{
    public long ConducteurId { get; set; }
    public long LocalisationDepartId { get; set; }
    public long LocalisationArriveeId { get; set; }
    public DateTime DateHeure { get; set; }
    public int NombrePlaces { get; set; }
}

public class TrajetAvecCoordonneesResquestDTO
{
    public long ConducteurId { get; set; }
    public DateTime DateHeure { get; set; }
    public int NombrePlaces { get; set; }
    public string AdresseDepart { get; set; }
    public double LongitudeDepart { get; set; }
    public double LatitudeDepart { get; set; }
    public string AdresseArrivee { get; set; }
    public double LongitudeArrivee { get; set; }
    public double LatitudeArrivee { get; set; }
}

public class TrajetResponseDTO
{
    public long Id { get; set; }
    public LocalisationResponseDTO? LocalisationDepart { get; set; }
    public LocalisationResponseDTO? LocalisationArrivee { get; set; }
    public UtilisateurResponseDTO? Conducteur { get; set; }
    public DateTime DateHeure { get; set; }
    public int NombrePlaces { get; set; }
}

public class TrajetUtilisateurResponseDTO
{
    public long Id { get; set; }
    public DateTime DateHeure { get; set; }
    public int NombrePlaces { get; set; }
    public LocalisationResponseDTO? LocalisationDepart { get; set; }
    public LocalisationResponseDTO? LocalisationArrivee { get; set; }
    public string Role { get; set; }
}