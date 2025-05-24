using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.Business.Repository;

public interface ILocalisationRepository
{
    Task<Localisation> Create(Localisation localisation);
    Task<List<Localisation>> FindAll();
    Task<Localisation?> FindById(long? localisationId);
} 