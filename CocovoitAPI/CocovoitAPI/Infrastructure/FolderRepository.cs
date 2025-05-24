using CocovoitAPI.Application.DTO.@in.Folder;
using CocovoitAPI.Domain.exception;
using CocovoitAPI.Domain.models;
using CocovoitAPI.Domain.repositories;
using Microsoft.EntityFrameworkCore;

namespace CocovoitAPI.Infrastructure;

public class FolderRepository : ApplicationDbContext, IFolderRepository
{
    public DbSet<Folder> Folders { get; set; }

    public async Task<List<Folder>> findAllByIdUtilisateur(long idUtilisateur)
    {
        List<Folder> folders = await Folders
               .Where(f => f.UtilisateurId == idUtilisateur)
               .ToListAsync();

        return folders;
    }

    public async Task<Folder> create(Folder folder)
    {
        try
        {
            Folders.Add(folder);
            await SaveChangesAsync();
            return folder;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<Folder> findById(long id)
    {
        Folder? folder = await Folders.FindAsync(id);
        if (folder != null)
        {
            return folder;
        }
        else
        {
            throw new FolderNotFoundException();
        }
    }

    public async Task delete(long id)
    {
        Folder folder = await findById(id);
        Folders.Remove(folder);
        await SaveChangesAsync();
    }

    public async Task<bool> exists(long id)
    {
        Folder folder = await findById(id);
        return await Folders.ContainsAsync(folder);
    }

    public async Task<Folder> update(Folder newFolder)
    {
        Folder folder = await findById(newFolder.Id);
        if (!string.IsNullOrWhiteSpace(folder.Name))
        {
            folder.Name = newFolder.Name;
        }
        await SaveChangesAsync();
        return folder;
    }
}