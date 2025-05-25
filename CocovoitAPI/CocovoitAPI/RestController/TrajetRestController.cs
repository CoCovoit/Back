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
    public async Task<ActionResult<List<TrajetResponseDTO>>> Proximite([FromQuery] double latitude, [FromQuery] double longitude)
    {
        throw new NotImplementedException();
    }


    /*private readonly FolderService _folderService;
    private readonly FolderMapper _folderMapper;
    public FolderController(FolderService folderService, FolderMapper folderMapper)
    {
        _folderService = folderService;
        _folderMapper = folderMapper;
    }
    [HttpGet("")]
    public async Task<ActionResult<List<FolderResponseDTO>>> index([FromQuery] long idUtilisateur)
    {
        try
        {
            List<Folder> folders = await _folderService.findAllByUtilisateur(idUtilisateur);
            List<FolderResponseDTO> foldersDTO = folders.Select(folder => _folderMapper.toDTO(folder)).ToList();
            return Ok(foldersDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/reports")]
    public async Task<ActionResult<List<ReportResponseDTO>>> getReports(long id)
    {
        try
        {
            List<ReportResponseDTO> reports = await _folderService.getReports(id);
            return Ok(reports);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<FolderResponseDTO>> save([FromBody] FolderCreateRequestDTO requestDTO)
    {
        try
        {
            Folder folder = await _folderService.save(_folderMapper.toEntity(requestDTO));
            return Ok(_folderMapper.toDTO(folder));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(long id)
    {
        try
        {
            await _folderService.delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<FolderResponseDTO>> update([FromBody] FolderUpdateRequestDTO requestDTO)
    {
        try
        {
            Folder folder = await _folderService.update(_folderMapper.toEntity(requestDTO));
            return Ok(_folderMapper.toDTO(folder));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }*/
}