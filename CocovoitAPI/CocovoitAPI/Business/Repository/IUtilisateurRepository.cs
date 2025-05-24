using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.Business.Repository;

public interface IUtilisateurRepository
{
    Task<Utilisateur> Create(Utilisateur utilisateur);
    Task<List<Utilisateur>> FindAll();
} 