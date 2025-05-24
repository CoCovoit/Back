using CocovoitAPI.Application.DTO.@in.Tag;
using CocovoitAPI.Application.DTO.@out;
using CocovoitAPI.Domain.exception;
using CocovoitAPI.Domain.models;

namespace CocovoitAPI.Application.mappers;

public class FolderTagMapper
{
    public FolderTag toEntity(long tagId, long? folderId)
    {
        if (folderId != null)
        {
            return new FolderTag()
            {
                FolderId = (long)folderId,
                TagId = tagId,
            };

        }
        throw new FolderTagLinkException();
    }

    public FolderTagResponseDTO toDTO(FolderTag folderTag)
    {
        return new FolderTagResponseDTO()
        {
            FolderId = folderTag.FolderId,
            TagId = folderTag.TagId,
        };
    }
}