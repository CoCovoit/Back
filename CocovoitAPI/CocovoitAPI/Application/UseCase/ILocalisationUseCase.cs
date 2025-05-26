using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.Application.UseCase;

public interface ILocalisationUseCase
{
    Task<Localisation> Create(Localisation localisation);
    Task<List<Localisation>> FindAll();
    Task<Localisation> FindById(long id);
    Task<Localisation> FindByCoordonnees(double longitude, double latitude, string adresse);
}