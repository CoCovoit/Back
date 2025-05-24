using CocovoitAPI.Application;
using CocovoitAPI.Application.DTO.@in.Report;
using CocovoitAPI.Application.DTO.@out;
using CocovoitAPI.Application.mappers;
using CocovoitAPI.Domain.models;
using Microsoft.AspNetCore.Mvc;

namespace CocovoitAPI.Controllers;

[ApiController]
[Route("Reports")]
public class ReportController : ControllerBase
{
    /*private readonly ReportService _reportService;
    private readonly ReportMapper _reportMapper;

    public ReportController(ReportService reportService, ReportMapper reportMapper)
    {
        _reportService = reportService;
        _reportMapper = reportMapper;
    }

    [HttpPost]
    public async Task<ActionResult<ReportResponseDTO>> create([FromBody] ReportRequestDTO requestDTO)
    {
        try
        {
            Report response = await _reportService.save(_reportMapper.toEntity(requestDTO));
            return Created(nameof(ReportResponseDTO), _reportMapper.toDTO(response));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReportResponseDTO>> getById(long id)
    {
        try
        {
            Report response = await _reportService.findById(id);
            return Ok(_reportMapper.toDTO(response));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("GenerateResume")]
    public async Task<ActionResult<string>> resumePrompt([FromBody] ReportResumePromptRequestDTO request)
    {
        try
        {
            string response = await _reportService.getResume(request);
            return Ok(response);
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
            await _reportService.delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<ReportResponseDTO>> update([FromBody] ReportUpdateRequestDTO requestDTO)
    {
        try
        {
            Report report = await _reportService.update(_reportMapper.toEntity(requestDTO));
            return Ok(_reportMapper.toDTO(report));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }*/
}