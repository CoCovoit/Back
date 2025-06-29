using CocovoitAPI.Business.Entity;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Utilisateur> Utilisateurs { get; set; }
    public DbSet<Trajet> Trajets { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Localisation> Localisations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseMySql("Server=localhost;Database=cocovoit;User=root;Password=cocovoit;",
        //     new MySqlServerVersion(new Version(8, 0, 21)));
        optionsBuilder.UseMySql("Server=mysql;Database=cocovoit;User=root;Password=cocovoit;",
           new MySqlServerVersion(new Version(8, 0, 21)),
           mysqlOptions =>
           {
               mysqlOptions.EnableRetryOnFailure(
                     maxRetryCount: 10, // Nombre maximum de tentatives
                     maxRetryDelay: TimeSpan.FromSeconds(10), // Délai maximal entre les tentatives
                     errorNumbersToAdd: null // Ajouter des codes d'erreur spécifiques si nécessaire
               );
           })
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
            .HasKey(r => new { r.UtilisateurId, r.TrajetId });

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Utilisateur)
            .WithMany(u => u.Reservations)
            .HasForeignKey(r => r.UtilisateurId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Trajet)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TrajetId);

        modelBuilder.Entity<Trajet>()
            .HasOne(t => t.Conducteur)
            .WithMany(u => u.TrajetsEnTantQueConducteur)
            .HasForeignKey(t => t.ConducteurId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Trajet>()
            .HasOne(t => t.LocalisationDepart)
            .WithMany()
            .HasForeignKey(t => t.LocalisationDepartId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Trajet>()
            .HasOne(t => t.LocalisationArrivee)
            .WithMany()
            .HasForeignKey(t => t.LocalisationArriveeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Utilisateur>()
            .HasOne(u => u.Localisation)
            .WithMany()
            .HasForeignKey(u => u.LocalisationId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

}