using CocovoitAPI.Business.Entity;

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
}