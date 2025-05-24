using CocovoitAPI.Application.UseCase.Exception;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.Business.Repository;

namespace CocovoitAPI.Application.UseCase;

public class LocalisationUseCase : ILocalisationUseCase
{
    private readonly ILocalisationRepository _repo;

    public LocalisationUseCase(ILocalisationRepository repo)
    {
        this._repo = repo;
    }

    public async Task<Localisation> Create(Localisation localisation)
    {
        return await _repo.Create(localisation);
    }

    public async Task<List<Localisation>> FindAll()
    {
        return await _repo.FindAll();
    }

    public async Task<Localisation> FindById(long id)
    {
        Localisation? localisation = await _repo.FindById(id);
        if (localisation != null)
        {
            return localisation;
        }
        else
        {
            throw new LocalisationNotFoundException(id);
        }
    }
}