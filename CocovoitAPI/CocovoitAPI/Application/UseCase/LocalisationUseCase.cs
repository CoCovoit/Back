using CocovoitAPI.Application.Exception;
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

    /// <summary>
    /// Récupère une localisation approchant un rayon de 100 mètres
    /// Si aucune localisation est trouvé, une nouvelle est créée.
    /// </summary>
    /// <param name="longitude"></param>
    /// <param name="latitude"></param>
    /// <param name="adresse"></param>
    /// <returns></returns>
    public async Task<Localisation> FindByCoordonnees(double longitude, double latitude, string adresse)
    {
        Localisation? localisation = _repo.FindByCoordonnees(longitude, latitude);
        return localisation != null ? localisation : await Create(new Localisation(adresse, longitude, latitude));
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