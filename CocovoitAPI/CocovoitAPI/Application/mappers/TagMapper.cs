using CocovoitAPI.Application.DTO.@in.Tag;
using CocovoitAPI.Application.DTO.@out;
using CocovoitAPI.Domain.models;

namespace CocovoitAPI.Application.mappers;

public class TagMapper
{
    public Tag toEntity(TagCreationRequestDTO dto)
    {
        if (!string.IsNullOrWhiteSpace(dto.Name))
        {
            return new Tag()
            {
                Name = dto.Name,
            };

        }
        throw new ArgumentNullException(nameof(dto.Name));
    }

    public TagResponseDTO toDTO(Tag tag)
    {
        return new TagResponseDTO()
        {
            Id = tag.Id,
            Name = tag.Name,
        };
    }
}