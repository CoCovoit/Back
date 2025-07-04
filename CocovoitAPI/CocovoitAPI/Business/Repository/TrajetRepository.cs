using CocovoitAPI.Business.Entity;
using CocovoitAPI.RestController.Dto;
using Microsoft.EntityFrameworkCore;

namespace CocovoitAPI.Business.Repository;

public class TrajetRepository : ITrajetRespository
{
    private readonly ApplicationDbContext _context;
    public TrajetRepository(ApplicationDbContext applicationDbContext) {
        _context = applicationDbContext;
    }
    public async Task<Trajet> Create(Trajet trajet)
    {
        await _context.Trajets.AddAsync(trajet);
        await _context.SaveChangesAsync();
        return trajet;
    }

    public List<Trajet> FindByConducteur(long id)
    {
        return _context.Trajets
            .Include(t => t.LocalisationDepart)
            .Include(t=> t.LocalisationArrivee)
            .Include(t=> t.Conducteur.Localisation)
            .Where(t => t.ConducteurId == id)
            .ToList();
    }

    public async Task<Trajet?> FindById(long id)
    {
        return await _context.Trajets
            .Include(t=> t.Conducteur)
            .Include(t=> t.LocalisationDepart)
            .Include(t=> t.LocalisationArrivee)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public List<Trajet> FindTrajetsProximite(double latitude, double longitude)
    {
        DateTime now = DateTime.Now;

        const double rayonMetres = 1000;

        // Récupération des trajets avec leur localisation
        var trajets = _context.Trajets
            .Include(t => t.LocalisationDepart)
            .Include(t => t.LocalisationArrivee)
            .Include(t => t.Conducteur)
            .ToList();

        // Filtrage selon la distance
        return trajets.Where(t =>
            t.LocalisationDepart != null && 
            t.DateHeure > now.AddDays(-1)
            && DistanceEnMetres(latitude, longitude, t.LocalisationDepart.Latitude, t.LocalisationDepart.Longitude) <= rayonMetres
        ).ToList();
    }

    private double DistanceEnMetres(double lat1, double lon1, double lat2, double lon2)
    {
        const double rayonTerre = 6371000; // rayon de la Terre en mètres

        double dLat = DegresEnRadians(lat2 - lat1);
        double dLon = DegresEnRadians(lon2 - lon1);

        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(DegresEnRadians(lat1)) * Math.Cos(DegresEnRadians(lat2)) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return rayonTerre * c;
    }

    private double DegresEnRadians(double degres)
    {
        return degres * (Math.PI / 180);
    }

}