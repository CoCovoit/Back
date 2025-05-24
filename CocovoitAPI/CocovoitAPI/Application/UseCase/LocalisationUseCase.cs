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
}