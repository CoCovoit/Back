namespace CocovoitAPI.RestController.Dto;

public class UtilisateurRequestDTO
{
    public string Nom { get; set; }
    public long LocalisationId { get; set; }
}

public class UtilisateurResponseDTO
{
    public long Id { get; set; }
    public string Nom { get; set; }
    public LocalisationResponseDTO? localisation {  get; set; }
}