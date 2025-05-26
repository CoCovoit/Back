using CocovoitAPI.Application.Exception;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.Business.Repository;
using CocovoitAPI.RestController.Dto;

namespace CocovoitAPI.Application.UseCase;

public class TrajetUseCase : ITrajetUseCase
{
    private readonly ITrajetRespository repo;
    private readonly IReservationUseCase reservationUseCase;
    public TrajetUseCase(ITrajetRespository repo, IReservationUseCase reservationUseCase)
    {
        this.repo = repo;
        this.reservationUseCase = reservationUseCase;
    }
    public async Task<Trajet> Create(Trajet trajet)
    {
        return await repo.Create(trajet);
    }

    public async Task<Trajet> FindById(long id)
    {
        Trajet? trajet = await repo.FindById(id);
        if (trajet == null) { 
            throw new TrajetNotFoundException(id);
        }
        return trajet;

    }

    public List<Trajet> FindByConducteur(long id)
    {
        return repo.FindByConducteur(id);
    }

    public List<Trajet> FindTrajetsProximite(double latitude, double longitude)
    {
        return repo.FindTrajetsProximite(latitude, longitude);
    }
}