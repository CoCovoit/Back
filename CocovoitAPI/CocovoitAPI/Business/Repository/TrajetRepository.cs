using CocovoitAPI.Business.Entity;
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
}