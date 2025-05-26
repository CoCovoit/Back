using AutoMapper;
using CocovoitAPI.RestController.Dto;
using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.RestController.Mappers;

public class LocalisationMapper
{
    private readonly IMapper _mapper;

    public LocalisationMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public LocalisationResponseDTO ToDto(Localisation localisation)
    {
        return _mapper.Map<LocalisationResponseDTO>(localisation);
    }

    public Localisation ToEntity(LocalisationRequestDTO localisation)
    {
        return _mapper.Map<Localisation>(localisation);
    }
}