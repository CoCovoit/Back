namespace CocovoitAPI.RestController.Dto;

public class UtilisateurRequestDTO
{
    public required string Nom { get; set; }
    
    public long LocalisationId { get; set; }
    
    public required string Email { get; set; }
}

public class UtilisateurResponseDTO
{
    public long Id { get; set; }
    
    public required string Nom { get; set; }
    
    public required string Email { get; set; }
    
    public LocalisationResponseDTO? Localisation {  get; set; }
}