using CocovoitAPI.Business.Entity;
using CocovoitAPI.RestController.Dto;

namespace CocovoitAPI.Application.UseCase;

public interface ITrajetUseCase
{
    Task<Trajet> Create(Trajet trajet);
    Task<Trajet> FindById(long idTrajet);
    List<Trajet> FindByConducteur(long id);
    List<Trajet> FindTrajetsProximite(double latitude, double longitude);
}