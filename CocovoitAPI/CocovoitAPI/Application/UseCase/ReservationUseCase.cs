using CocovoitAPI.Application.Exception;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.Business.Repository;

namespace CocovoitAPI.Application.UseCase;

public class ReservationUseCase : IReservationUseCase
{
    private readonly IReservationRepository reservationRepository;
    public ReservationUseCase(IReservationRepository reservationRepository)
    {
        this.reservationRepository = reservationRepository;
    }

    public async Task<Reservation> Create(Reservation reservation)
    {
        if (await reservationRepository.Exist(reservation))
        {
            throw new ReservationAllReadyExistException();
        }
        return await this.reservationRepository.Create(reservation);
    }

    public List<Reservation> FindByUtilisateur(int id)
    {
        return reservationRepository.FindByUtilisateur(id);
    }
}