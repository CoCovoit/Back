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
    private readonly IUtilisateurUseCase _useCase;

    public UtilisateurRestController(UtilisateurMapper localizationMapper, IUtilisateurUseCase useCase)
    {
        _mapper = localizationMapper;
        _useCase = useCase;
    }

    [HttpPost]
    public async Task<ActionResult<UtilisateurResponseDTO>> create([FromBody] UtilisateurRequestDTO requestDTO)
    {
        try
        {
            Utilisateur utilisateur = await _useCase.Create(await _mapper.ToEntity(requestDTO));
            return Created(nameof(UtilisateurResponseDTO), _mapper.ToDto(utilisateur));
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<UtilisateurResponseDTO>>> Index()
    {
        List<Utilisateur> utilisateurs = await this._useCase.FindAll();
        return utilisateurs.Select(u => _mapper.ToDto(u)).ToList();
    }
}