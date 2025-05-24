using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.Application.UseCase;

public interface ILocalisationUseCase
{
    Task<Localisation> Create(Localisation localisation);
    Task<List<Localisation>> FindAll();
}