namespace CocovoitAPI.Business.Entity.Events;

public record DetailsTrajetDto(
    string AdresseDepart,
    string AdresseArrivee,
    DateTime DateHeure,
    int NombrePlaces,
    string NomConducteur,
    string EmailConducteur
);