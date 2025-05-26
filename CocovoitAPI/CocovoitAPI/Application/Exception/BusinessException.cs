using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.Application.Exception;

public class ReservationAllReadyExistException : KeyNotFoundException
{
    public ReservationAllReadyExistException() : base($"Une réservation est déjà présente pour ce trajet.") { }
}