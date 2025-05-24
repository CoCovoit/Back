using CocovoitAPI.Application.DTO.@in.Folder;
using CocovoitAPI.Domain.models;

namespace CocovoitAPI.Domain.repositories;

public interface IFolderRepository
{
    public Task<List<Folder>> findAllByIdUtilisateur(long idUtilisateur);

    public Task<Folder> create(Folder folder);

    public Task delete(long id);

    public Task<bool> exists(long id);

    public Task<Folder> update(Folder folder);
}