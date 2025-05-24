
using Microsoft.EntityFrameworkCore;

namespace CocovoitAPI.Application;

public class MigrationService : ApplicationDbContext, IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Initialize();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine(cancellationToken.ToString());
    }

    private async Task Initialize()
    {
        /*string sql = @"
            USE comete;

            CREATE TABLE IF NOT EXISTS Utilisateurs (
                id BIGINT NOT NULL AUTO_INCREMENT,
                email VARCHAR(255) NOT NULL,
                password VARCHAR(255) NOT NULL,
                PRIMARY KEY (id)
            );

            CREATE TABLE IF NOT EXISTS Folders (
                id BIGINT NOT NULL AUTO_INCREMENT,
                name VARCHAR(255) NOT NULL,
                utilisateur_id BIGINT NOT NULL,
                PRIMARY KEY (id),
                FOREIGN KEY (utilisateur_id) REFERENCES Utilisateurs(id)
            );

            CREATE TABLE IF NOT EXISTS Reports (
                id BIGINT NOT NULL AUTO_INCREMENT,
                name VARCHAR(255) NOT NULL,
                content TEXT NOT NULL,
                folder_id BIGINT NOT NULL,
                PRIMARY KEY (id),
                FOREIGN KEY (folder_id) REFERENCES Folders(id)
            );

            CREATE TABLE IF NOT EXISTS Tags (
                id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                name VARCHAR(255) NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Folder_tags (
                folder_id BIGINT NOT NULL,
                tag_id BIGINT NOT NULL,
                PRIMARY KEY (folder_id, tag_id),
                FOREIGN KEY (folder_id) REFERENCES Folders(id) ON DELETE CASCADE,
                FOREIGN KEY (tag_id) REFERENCES Tags(id) ON DELETE CASCADE
            );
            
            INSERT INTO Utilisateurs (email, password)
            SELECT 'comete@esgi.fr', 'comete'
            WHERE NOT EXISTS (
                SELECT 1 FROM Utilisateurs WHERE email = 'comete@esgi.fr'
            );
        ";
        if (await Database.CanConnectAsync())
        {
            Database.ExecuteSqlRaw(sql);
        }*/
    }
}