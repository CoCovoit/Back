using CocovoitAPI.Application.UseCase;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.RestController.Dto;
using CocovoitAPI.RestController.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CocovoitAPI.RestController;

[ApiController]
[Route("Trajets")]
public class TrajetRestController : ControllerBase
{
    private readonly ITrajetUseCase useCase;
    private readonly TrajetMapper mapper;

    public TrajetRestController(ITrajetUseCase useCase, TrajetMapper mapper)
    {
        this.useCase = useCase;
        this.mapper = mapper;
    }

    /// <summary>
    /// Ajout de trajet
    /// </summary>
    /// <param name="requestDTO"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<TrajetResponseDTO>> Create([FromBody] TrajetRequestDTO requestDTO)
    {
        try
        {
            Trajet trajet = await useCase.Create(await mapper.ToEntity(requestDTO));
            return Created(nameof(Trajet), mapper.ToDTO(trajet));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Ajout de trajet par coordonnées
    /// </summary>
    /// <param name="requestDTO"></param>
    /// <returns></returns>
    [HttpPost("Coordonnees")]
    public async Task<ActionResult<TrajetResponseDTO>> CreateAvecCoordonnees([FromBody] TrajetAvecCoordonneesResquestDTO requestDTO)
    {
        try
        {
            Trajet trajet = await useCase.Create(await mapper.ToEntity(requestDTO));
            return Created(nameof(Trajet), mapper.ToDTO(trajet));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Récupère la liste des trajets disponibles à proximité d'une localisation
    /// </summary>
    /// <param name="latitude"></param>
    /// <param name="longitude"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("Proximite")]
    public ActionResult<List<TrajetResponseDTO>> Proximite([FromQuery] double latitude, [FromQuery] double longitude)
    {
        List<Trajet> trajetsDisponible = useCase.FindTrajetsProximite(latitude, longitude);
        return Ok(trajetsDisponible.Select(tb => mapper.ToDTO(tb)));
    }
}