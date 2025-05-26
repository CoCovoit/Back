using CocovoitAPI.Application.UseCase;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.RestController.Dto;
using CocovoitAPI.RestController.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CocovoitAPI.RestController;

[ApiController]
[Route("Utilisateurs")]
public class UtilisateurRestController : ControllerBase
{
    private readonly UtilisateurMapper _mapper;
    private readonly TrajetMapper _trajetMapper;
    private readonly IUtilisateurUseCase _useCase;
    private readonly ITrajetUseCase _tajetUseCase;
    private readonly IReservationUseCase _reservationUseCase;

    public UtilisateurRestController(UtilisateurMapper localizationMapper, IUtilisateurUseCase useCase, ITrajetUseCase tajetUseCase, TrajetMapper trajetMapper, IReservationUseCase reservationUseCase)
    {
        _mapper = localizationMapper;
        _useCase = useCase;
        _tajetUseCase = tajetUseCase;
        _trajetMapper = trajetMapper;
        _reservationUseCase = reservationUseCase;
    }

    /// <summary>
    /// Ajout d'utilisateur
    /// </summary>
    /// <param name="requestDTO"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<UtilisateurResponseDTO>> create([FromBody] UtilisateurRequestDTO requestDTO)
    {
        try
        {
            Utilisateur utilisateur = await _useCase.Create(await _mapper.ToEntity(requestDTO));
            return Created(nameof(UtilisateurResponseDTO), _mapper.ToDto(utilisateur));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Liste des utilisateurs
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<List<UtilisateurResponseDTO>>> Index()
    {
        List<Utilisateur> utilisateurs = await this._useCase.FindAll();
        return Ok(utilisateurs.Select(u => _mapper.ToDto(u)).ToList());
    }

    /// <summary>
    /// Retourne les trajets associés à un utilisateur (conducteur/passager)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}/Trajets")]
    public ActionResult<List<TrajetResponseDTO>> Trajets(int id)
    {
        List<Trajet> trajetsConducteur = _tajetUseCase.FindByConducteur(id);
        List<Trajet> trajetsPassager = _reservationUseCase.FindByUtilisateur(id)
            .Where(r => r.Trajet != null)
            .Select(r => r.Trajet)
            .ToList();

        List<TrajetUtilisateurResponseDTO> response = trajetsConducteur
            .Select(tc => _trajetMapper.ToDTO(tc, "C"))
            .Concat(trajetsPassager.Select(tp => _trajetMapper.ToDTO(tp, "P")))
            .Distinct().ToList();

        return Ok(response);
    }
}