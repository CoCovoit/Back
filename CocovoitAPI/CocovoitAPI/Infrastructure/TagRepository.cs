using CocovoitAPI.Domain.exception;
using CocovoitAPI.Domain.models;
using CocovoitAPI.Domain.repositories;
using Microsoft.EntityFrameworkCore;

namespace CocovoitAPI.Infrastructure;

public class TagRepository : ApplicationDbContext, ITagRepository
{
    public DbSet<Tag> Tags { get; set; }
    public async Task<Tag> save(Tag tag)
    {
        await Tags.AddAsync(tag);
        await SaveChangesAsync();
        return tag;
    }
    public async Task delete(long id)
    {
        Tag tag = await findById(id);
        Tags.Remove(tag);
        await SaveChangesAsync();
    }

    private async Task<Tag> findById(long id)
    {
        Tag? tag = await Tags.FindAsync(id);
        if (tag != null)
        {
            return tag;
        }
        else
        {
            throw new TagNotFoundException();
        }
    }

    public async Task<List<Tag>> findAll()
    {
        return await Tags.ToListAsync();
    }

    public async Task<bool> exists(long id)
    {
        Tag tag = await findById(id);
        return await Tags.ContainsAsync(tag);
    }
}