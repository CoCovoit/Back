using System.Text.Json;
using CocovoitAPI.Application.Bus;
using CocovoitAPI.Application.Exception;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.Business.Entity.Events;
using CocovoitAPI.Business.Repository;
using CocovoitAPI.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace CocovoitAPI.Application.UseCase;

public class ReservationUseCase : IReservationUseCase
{
    private readonly IReservationRepository reservationRepository;
    private readonly IEventBus _eventBus;
    private readonly KafkaSettings _kafka;

    public ReservationUseCase(IReservationRepository reservationRepository, 
        IEventBus eventBus,
        IOptions<KafkaSettings> kafkaOptions)
    {
        this.reservationRepository = reservationRepository;
        _eventBus = eventBus;
        _kafka = kafkaOptions.Value;
    }

    public async Task<Reservation> Create(Reservation reservation)
    {
        if (await reservationRepository.Exist(reservation))
        {
            throw new ReservationAllReadyExistException();
        }
        var saved = await reservationRepository.Create(reservation);

        var evt = new ReservationCreatedEvent(
            TrajetId: saved.TrajetId,
            UtilisateurId: saved.UtilisateurId,
            EmailUtilisateur: saved.Utilisateur.Email,
            DateReservation: DateTime.UtcNow,
            DetailsTrajet:  "Ici on mettra le détail du trajet" // TODO
        );

        var payload = JsonSerializer.Serialize(evt);

        await _eventBus.PublishAsync(_kafka.TopicReservationCreated, null, payload);

        return saved;
    }

    public List<Reservation> FindByUtilisateur(int id)
    {
        return reservationRepository.FindByUtilisateur(id);
    }
}