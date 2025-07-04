using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.Business.Repository;

public interface IReservationRepository
{
    Task<Reservation> Create(Reservation reservation);
    Task<bool> Exist(Reservation reservation);
    List<Reservation> FindByUtilisateur(int id);
    Task<Reservation> GetWithDetailsAsync(long utilisateurId, long trajetId);
}