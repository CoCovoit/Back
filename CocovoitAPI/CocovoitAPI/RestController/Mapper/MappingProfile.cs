using AutoMapper;
using CocovoitAPI.RestController.Dto;
using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.RestController.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LocalisationRequestDTO, Localisation>();
        CreateMap<Localisation, LocalisationResponseDTO>();

        CreateMap<UtilisateurRequestDTO, Utilisateur>();
        CreateMap<Utilisateur, UtilisateurResponseDTO>();

        CreateMap<TrajetRequestDTO, Trajet>();
        CreateMap<TrajetAvecCoordonneesResquestDTO, Trajet>();
        CreateMap<Trajet, TrajetResponseDTO>();
        CreateMap<Trajet, TrajetUtilisateurResponseDTO>();

        CreateMap<ReservationRequestDTO, Reservation>();
        CreateMap<Reservation, ReservationResponseDTO>();
    }
}
