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

    public Localisation? FindByCoordonnees(double longitude, double latitude)
    {
        const double rayonMetres = 100.0;
        const double rayonDegres = 0.001;

        return _dbContext.Localisations
            .Where(l =>
            l.Latitude >= latitude - rayonDegres &&
            l.Latitude <= latitude + rayonDegres &&
            l.Longitude >= longitude - rayonDegres &&
            l.Longitude <= longitude + rayonDegres)
        .AsEnumerable() // Passe à une évaluation côté client (en mémoire)
        .FirstOrDefault(l =>
            DistanceEnMetres(latitude, longitude, l.Latitude, l.Longitude) <= rayonMetres);
    }

    public async Task<Localisation?> FindById(long? id)
    {
        return await _dbContext.Localisations.FindAsync(id);
    }

    private double DistanceEnMetres(double lat1, double lon1, double lat2, double lon2)
    {
        const double R = 6371000; // Rayon de la Terre en mètres
        double dLat = DegresEnRadians(lat2 - lat1);
        double dLon = DegresEnRadians(lon2 - lon1);

        double a =
            Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
            Math.Cos(DegresEnRadians(lat1)) * Math.Cos(DegresEnRadians(lat2)) *
            Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return R * c;
    }

    private double DegresEnRadians(double degres)
    {
        return degres * (Math.PI / 180);
    }
}