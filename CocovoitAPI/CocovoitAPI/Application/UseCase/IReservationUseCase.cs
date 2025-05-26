using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.Application.UseCase;

public interface IReservationUseCase
{
    Task<Reservation> Create(Reservation reservation);
    List<Reservation> FindByUtilisateur(int id);
}