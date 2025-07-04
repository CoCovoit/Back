using CocovoitAPI.RestController.Dto;
using CocovoitAPI.RestController.Mappers;
using Microsoft.AspNetCore.Mvc;
using CocovoitAPI.Application.UseCase;
using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.RestController;

[ApiController]
[Route("Localisations")]
public class LocalisationRestController : ControllerBase
{
    private readonly LocalisationMapper _mapper;
    private readonly ILocalisationUseCase _useCase;

    public LocalisationRestController(LocalisationMapper localizationMapper, ILocalisationUseCase useCase)
    {
        _mapper = localizationMapper;
        _useCase = useCase;
    }

    /// <summary>
    /// Ajout de localisation
    /// </summary>
    /// <param name="requestDTO"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<LocalisationResponseDTO>> Create([FromBody] LocalisationRequestDTO requestDTO)
    {
        try
        {
            Localisation localisation = await _useCase.Create(_mapper.ToEntity(requestDTO));
            return Created(nameof(LocalisationResponseDTO), _mapper.ToDto(localisation));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Liste des localisations
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<List<LocalisationResponseDTO>>> Index()
    {
        List<Localisation> sportifs = await this._useCase.FindAll();
        return sportifs.Select(s => _mapper.ToDto(s)).ToList();
    }
}