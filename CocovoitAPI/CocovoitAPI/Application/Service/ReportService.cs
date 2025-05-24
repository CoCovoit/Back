using CocovoitAPI.Application.DTO.@in.Report;
using CocovoitAPI.Application.Service;
using CocovoitAPI.Domain.exception;
using CocovoitAPI.Domain.models;
using CocovoitAPI.Domain.repositories;

namespace CocovoitAPI.Application;

public class ReportService
{
    private readonly OpenAiService _openAiService;
    private readonly IReportRepository _reportReporitory;
    private readonly FolderService _folderService;

    public ReportService(OpenAiService openAiService, IReportRepository reportReporitory, FolderService folderService)
    {
        _openAiService = openAiService;
        _reportReporitory = reportReporitory;
        _folderService = folderService;
    }

    public async Task<Report> save(Report report)
    {
        if (await _folderService.exists(report.FolderId))
        {
            Report newReport = await _reportReporitory.save(report);
            return newReport;
        }
        else
        {
            throw new FolderNotFoundException();
        }
    }

    public async Task<string> getResume(ReportResumePromptRequestDTO requestDTO)
    {
        return await _openAiService.GetResumeAsync(requestDTO.Prompt, requestDTO.Instructions);
    }

    public async Task<Report> findById(long id)
    {
        return await _reportReporitory.findById(id);
    }

    public async Task delete(long id)
    {
        await _reportReporitory.delete(id);
    }

    private async Task<bool> exists(long id)
    {
        return await _reportReporitory.exists(id);
    }

    public async Task<Report> update(Report report)
    {
        if (await exists(report.Id))
        {
            return await _reportReporitory.update(report);
        }
        else
        {
            throw new ReportNotFoundException();
        }
    }
}