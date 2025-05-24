using CocovoitAPI.Application.DTO.@in.Tag;
using CocovoitAPI.Domain.exception;
using CocovoitAPI.Domain.models;
using CocovoitAPI.Domain.repositories;

namespace CocovoitAPI.Application;

public class TagService
{
    private readonly ITagRepository _tagRepository;
    private readonly IFolderTagReporitory _folderTagReporitory;
    private readonly FolderService _folderService;
    public TagService(ITagRepository tagRepository, IFolderTagReporitory folderTagReporitory, FolderService folderService)
    {
        _tagRepository = tagRepository;
        _folderTagReporitory = folderTagReporitory;
        _folderService = folderService;
    }

    public async Task<Tag> create(Tag tag)
    {
        return await _tagRepository.save(tag);
    }

    public async Task delete(long id)
    {
        await _tagRepository.delete(id);
    }

    public async Task<List<Tag>> findAll()
    {
        return await _tagRepository.findAll();
    }

    public async Task<FolderTag> linkFolder(FolderTag folderTag)
    {
        if (await _folderService.exists(folderTag.FolderId))
        {
            if (await _tagRepository.exists(folderTag.TagId))
            {
                return await _folderTagReporitory.save(folderTag);
            }
            throw new TagNotFoundException();
        }
        throw new FolderNotFoundException();
    }

    public List<Folder> findFolderByTagId(long tagId)
    {
        return _folderTagReporitory.findFolderByTagId(tagId);
    }

    public async Task unlink(FolderTag folderTag)
    {
        await _folderTagReporitory.delete(folderTag.FolderId, folderTag.TagId);
    }
}