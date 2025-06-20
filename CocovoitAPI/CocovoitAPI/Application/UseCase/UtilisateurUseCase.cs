using CocovoitAPI.Application.Exception;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.Business.Repository;

namespace CocovoitAPI.Application.UseCase;

public class UtilisateurUseCase : IUtilisateurUseCase
{
    private readonly IUtilisateurRepository _repo;

    public UtilisateurUseCase(IUtilisateurRepository repo)
    {
        this._repo = repo;
    }

    public async Task<Utilisateur> Create(Utilisateur utilisateur)
    {
        return await _repo.Create(utilisateur);
    }

    public async Task<List<Utilisateur>> FindAll()
    {
        return await _repo.FindAll();
    }

    public async Task<Utilisateur> FindById(long id)
    {
        Utilisateur? utilisateur = await _repo.FindById(id);
        if (utilisateur != null)
        {
            return utilisateur;
        }
        else
        {
            throw new UtilisateurNotFoundException(id);
        }
    }
}