using AutoMapper;
using CocovoitAPI.RestController.Dto;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.Application.UseCase;

namespace CocovoitAPI.RestController.Mappers;

public class UtilisateurMapper
{
    private readonly IMapper _mapper;
    private readonly ILocalisationUseCase _localisationUseCase;

    public UtilisateurMapper(IMapper mapper, ILocalisationUseCase localisationUseCase)
    {
        _mapper = mapper;
        this._localisationUseCase = localisationUseCase;
    }

    public UtilisateurResponseDTO ToDto(Utilisateur utilisateur)
    {
        return _mapper.Map<UtilisateurResponseDTO>(utilisateur);
    }

    public async Task<Utilisateur> ToEntity(UtilisateurRequestDTO requestDTO)
    {
        var utilisateur = _mapper.Map<Utilisateur>(requestDTO);
        utilisateur.Localisation = await _localisationUseCase.FindById(requestDTO.LocalisationId);
        return utilisateur;
    }
}