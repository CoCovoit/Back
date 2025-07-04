using CocovoitAPI.Business.Entity;
using Microsoft.EntityFrameworkCore;

namespace CocovoitAPI.Business.Repository;

public class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext dbContext;
    public ReservationRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<Reservation> Create(Reservation reservation)
    {
        await dbContext.Reservations.AddAsync(reservation);
        await dbContext.SaveChangesAsync();
        return reservation;
    }

    public async Task<bool> Exist(Reservation reservation)
    {
        return await dbContext.Reservations.AnyAsync(r => 
            r.TrajetId == reservation.TrajetId && r.UtilisateurId == reservation.UtilisateurId
        );
    }

    public List<Reservation> FindByUtilisateur(int id)
    {
        return dbContext.Reservations
            .Include(r => r.Trajet.LocalisationDepart)
            .Include(r => r.Trajet.LocalisationArrivee)
            .Include(r => r.Utilisateur.Localisation)
            .Where(r => r.UtilisateurId == id)
            .ToList();
    }
    
    public async Task<Reservation> GetWithDetailsAsync(long utilisateurId, long trajetId)
    {
        return await dbContext.Reservations
                   .Include(r => r.Utilisateur)
                   .Include(r => r.Trajet)
                   .ThenInclude(t => t.LocalisationDepart)
                   .Include(r => r.Trajet)
                   .ThenInclude(t => t.LocalisationArrivee)
                   .Include(r => r.Trajet)
                   .ThenInclude(t => t.Conducteur)
                   .FirstOrDefaultAsync(r => r.TrajetId == trajetId 
                                             && r.UtilisateurId == utilisateurId)
               ?? throw new Exception("Réservation non trouvée");
    }
}