namespace CocovoitAPI.Business.Entity.Events;

public record ReservationCreatedEvent(
    long TrajetId,
    long UtilisateurId,
    string EmailUtilisateur,
    DateTime DateReservation,
    string DetailsTrajet
);