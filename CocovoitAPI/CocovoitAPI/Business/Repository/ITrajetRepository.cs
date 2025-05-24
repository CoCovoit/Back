using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.Business.Repository;

public interface ITrajetRespository
{
    Task<Trajet> Create(Trajet trajet);
}