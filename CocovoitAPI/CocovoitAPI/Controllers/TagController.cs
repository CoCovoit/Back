using CocovoitAPI.Application;
using CocovoitAPI.Application.DTO.@in.Tag;
using CocovoitAPI.Application.DTO.@out;
using CocovoitAPI.Application.mappers;
using CocovoitAPI.Domain.models;
using Microsoft.AspNetCore.Mvc;

namespace CocovoitAPI.Controllers;

[ApiController]
[Route("Tags")]
public class TagController : ControllerBase
{
    /*private readonly TagService _tagService;
    private readonly TagMapper _tagMapper;
    private readonly FolderTagMapper _folderTagMapper;
    private readonly FolderMapper _folderMapper;
    public TagController(TagService tagService, TagMapper tagMapper, FolderTagMapper folderTagMapper, FolderMapper folderMapper = null)
    {
        _tagService = tagService;
        _tagMapper = tagMapper;
        _folderTagMapper = folderTagMapper;
        _folderMapper = folderMapper;
    }

    [HttpPost]
    public async Task<ActionResult<TagResponseDTO>> create([FromBody] TagCreationRequestDTO requestDTO)
    {
        try
        {
            Tag tag = await _tagService.create(_tagMapper.toEntity(requestDTO));
            return Created(nameof(Tag), _tagMapper.toDTO(tag));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}/linkFolder")]
    public async Task<ActionResult<FolderTagResponseDTO>> linkFolder(long id, [FromBody] FolderTagCreationRequestDTO requestDTO)
    {
        try
        {
            FolderTag folderTag = await _tagService.linkFolder(_folderTagMapper.toEntity(id, requestDTO.FolderId));
            return Ok(_folderTagMapper.toDTO(folderTag));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}/unlinkFolder")]
    public async Task<ActionResult<FolderTagResponseDTO>> unlinkFolder(long id, [FromBody] FolderTagCreationRequestDTO requestDTO)
    {
        try
        {
            await _tagService.unlink(_folderTagMapper.toEntity(id, requestDTO.FolderId));
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<TagResponseDTO>>> findAll()
    {
        try
        {
            List<Tag> tags = await _tagService.findAll();
            List<TagResponseDTO> tagResponseDTOs = tags.Select(tag => _tagMapper.toDTO(tag)).ToList();
            return Ok(tagResponseDTOs);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/folders")]
    public async Task<ActionResult<Folder>> folders(long id)
    {
        try
        {
            List<Folder> folders = _tagService.findFolderByTagId(id);
            List<FolderResponseDTO> foldersDTO = folders.Select(folder => _folderMapper.toDTO(folder)).ToList();
            return Ok(foldersDTO);
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
            await _tagService.delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }*/
}