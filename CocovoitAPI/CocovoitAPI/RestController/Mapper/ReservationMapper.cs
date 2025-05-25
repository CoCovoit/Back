using AutoMapper;
using CocovoitAPI.Application.UseCase;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.RestController.Dto;

namespace CocovoitAPI.RestController.Mappers;

public class ReservationMapper
{
    private readonly IMapper mapper;
    private readonly TrajetMapper trajetMapper;
    private readonly UtilisateurMapper utilisateurMapper;
    private readonly ITrajetUseCase trajetUseCase;
    private readonly IUtilisateurUseCase utilisateurUseCase;
    public ReservationMapper(IMapper mapper, ITrajetUseCase trajetUseCase, IUtilisateurUseCase utilisateurUseCase, TrajetMapper trajetMapper, UtilisateurMapper utilisateurMapper) { 
        this.mapper = mapper;
        this.utilisateurUseCase = utilisateurUseCase;
        this.trajetUseCase = trajetUseCase;
        this.utilisateurMapper = utilisateurMapper;
        this.trajetMapper = trajetMapper;
    }

    public async Task<Reservation> ToEntity(ReservationRequestDTO requestDTO) {
        Reservation reservation = mapper.Map<Reservation>(requestDTO);
        reservation.Trajet = await trajetUseCase.FindById(requestDTO.TrajetId);
        reservation.Utilisateur = await utilisateurUseCase.FindById(requestDTO.UtilisateurId);
        return reservation;
    }

    public ReservationResponseDTO ToDTO(Reservation reservation) { 
        ReservationResponseDTO response = mapper.Map<ReservationResponseDTO>(reservation);
        response.Trajet = trajetMapper.ToDTO(reservation.Trajet);
        response.Passager = utilisateurMapper.ToDto(reservation.Utilisateur);
        return response;
    }
}