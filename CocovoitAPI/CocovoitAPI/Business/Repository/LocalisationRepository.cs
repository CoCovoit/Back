using CocovoitAPI.Business.Entity;
using Microsoft.EntityFrameworkCore;

namespace CocovoitAPI.Business.Repository;

public class LocalisationRepository : ILocalisationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public LocalisationRepository(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<Localisation> Create(Localisation localisation)
    {
        await _dbContext.Localisations.AddAsync(localisation);
        await _dbContext.SaveChangesAsync();
        return localisation;
    }

    public Task<List<Localisation>> FindAll()
    {
        return _dbContext.Localisations.ToListAsync();
    }
}