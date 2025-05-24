using AutoMapper;
using CocovoitAPI.Application.UseCase;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.RestController.Dto;

namespace CocovoitAPI.RestController.Mappers;

public class TrajetMapper
{
    private readonly IMapper mapper;
    private readonly ILocalisationUseCase localisationUseCase;
    private readonly IUtilisateurUseCase utilisateurUseCase;
    private readonly LocalisationMapper localisationMapper;
    private readonly UtilisateurMapper utilisateurMapper;
    public TrajetMapper(IMapper mapper, ILocalisationUseCase localisationUseCase, LocalisationMapper localisationMapper, IUtilisateurUseCase utilisateurUseCase, UtilisateurMapper utilisateurMapper)
    {
        this.mapper = mapper;
        this.localisationUseCase = localisationUseCase;
        this.localisationMapper = localisationMapper;
        this.utilisateurUseCase = utilisateurUseCase;
        this.utilisateurMapper = utilisateurMapper;
    }

    public async Task<Trajet> ToEntity(TrajetRequestDTO trajetRequestDTO)
    {
        Trajet trajet = mapper.Map<Trajet>(trajetRequestDTO);
        trajet.LocalisationDepart = await localisationUseCase.FindById(trajetRequestDTO.LocalisationDepartId);
        trajet.LocalisationArrivee = await localisationUseCase.FindById(trajetRequestDTO.LocalisationArriveeId);
        trajet.Conducteur = await utilisateurUseCase.FindById(trajetRequestDTO.ConducteurId);
        return trajet;
    }

    public async Task<Trajet> ToEntity(TrajetAvecCoordonneesResquestDTO trajetRequestDTO)
    {
        Trajet trajet = mapper.Map<Trajet>(trajetRequestDTO);
        trajet.Conducteur = await utilisateurUseCase.FindById(trajetRequestDTO.ConducteurId);
        trajet.LocalisationDepart = await localisationUseCase.FindByCoordonnees(trajetRequestDTO.LongitudeDepart, trajetRequestDTO.LatitudeDepart, trajetRequestDTO.AdresseDepart);
        trajet.LocalisationArrivee = await localisationUseCase.FindByCoordonnees(trajetRequestDTO.LongitudeArrivee, trajetRequestDTO.LatitudeArrivee, trajetRequestDTO.AdresseArrivee);
        return trajet;
    }

    public TrajetResponseDTO ToDTO(Trajet trajet) { 
        TrajetResponseDTO responseDTO = mapper.Map<TrajetResponseDTO>(trajet);
        responseDTO.LocalisationDepart = localisationMapper.ToDto(trajet.LocalisationDepart);
        responseDTO.LocalisationArrivee = localisationMapper.ToDto(trajet.LocalisationArrivee);
        responseDTO.Conducteur = utilisateurMapper.ToDto(trajet.Conducteur);
        return responseDTO;
    }
}