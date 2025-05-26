namespace CocovoitAPI.RestController.Dto;

public class LocalisationRequestDTO
{
    public string Adresse { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}

public class LocalisationResponseDTO
{
    public long id { get; set; }
    public string Adresse { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}