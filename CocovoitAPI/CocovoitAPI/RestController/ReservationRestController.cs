using CocovoitAPI.RestController.Dto;
using CocovoitAPI.RestController.Mappers;
using Microsoft.AspNetCore.Mvc;
using CocovoitAPI.Application.UseCase;
using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.RestController;

[ApiController]
[Route("Reservations")]
public class ReservationRestController : ControllerBase
{
    private readonly ReservationMapper _mapper;
    private readonly IReservationUseCase _useCase;

    public ReservationRestController(ReservationMapper reservationMapper, IReservationUseCase useCase)
    {
        _mapper = reservationMapper;
        _useCase = useCase;
    }

    /// <summary>
    /// Associe un passager à un trajet
    /// </summary>
    /// <param name="requestDTO"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ReservationResponseDTO>> Create([FromBody] ReservationRequestDTO requestDTO)
    {
        try
        {
            Reservation reservation = await _useCase.Create(await _mapper.ToEntity(requestDTO));
            return Created(nameof(ReservationResponseDTO), _mapper.ToDTO(reservation));
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}