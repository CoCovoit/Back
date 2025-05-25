namespace CocovoitAPI.RestController.Dto;

public class ReservationRequestDTO
{
    public long UtilisateurId { get; set; }
    public long TrajetId { get; set; }
}

public class ReservationResponseDTO
{
    public UtilisateurResponseDTO? Passager { get; set; }
    public TrajetResponseDTO? Trajet { get; set; }
}