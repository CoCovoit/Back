using CocovoitAPI.Business.Entity;
using Microsoft.EntityFrameworkCore;

namespace CocovoitAPI.Business.Repository;

public class UtilisateurRepository : IUtilisateurRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UtilisateurRepository(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<Utilisateur> Create(Utilisateur utilisateur)
    {
        await _dbContext.Utilisateurs.AddAsync(utilisateur);
        await _dbContext.SaveChangesAsync();
        return utilisateur;
    }

    public Task<List<Utilisateur>> FindAll()
    {
        return _dbContext.Utilisateurs.Include(u => u.Localisation).ToListAsync();
    }
}