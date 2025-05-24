using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.Application.UseCase;

public interface IUtilisateurUseCase
{
    Task<Utilisateur> Create(Utilisateur utilisateur);
    Task<List<Utilisateur>> FindAll();
}