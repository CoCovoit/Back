using CocovoitAPI.Domain.models;

namespace CocovoitAPI.Domain.repositories;

public interface IFolderTagReporitory
{
    public Task<FolderTag> save(FolderTag folderTag);

    public List<Folder> findFolderByTagId(long tagId);
    public Task delete(long folderId, long tagId);
}