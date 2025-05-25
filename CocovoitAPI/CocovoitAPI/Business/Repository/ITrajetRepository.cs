using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.Business.Repository;

public interface ITrajetRespository
{
    Task<Trajet> Create(Trajet trajet);
    List<Trajet> FindByConducteur(long id);
    Task<Trajet?> FindById(long id);
}