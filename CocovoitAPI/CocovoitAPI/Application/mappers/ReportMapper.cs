using CocovoitAPI.Application.DTO.@in.Report;
using CocovoitAPI.Application.DTO.@out;
using CocovoitAPI.Domain.exception;
using CocovoitAPI.Domain.models;

namespace CocovoitAPI.Application.mappers;

public class ReportMapper
{
    public ReportResponseDTO toDTO(Report report)
    {
        ReportResponseDTO dto = new ReportResponseDTO();
        dto.Id = report.Id;
        dto.Name = report.Name;
        dto.Content = report.Content;
        return dto;
    }

    public Report toEntity(ReportRequestDTO report)
    {
        verifyRequest(report);
        return new Report()
        {
            Name = report.FileName,
            Content = report.Text,
            FolderId = report.IdFolder,
        };
    }

    public Report toEntity(ReportUpdateRequestDTO report)
    {
        verifyRequest(report);
        return new Report()
        {
            Id = report.Id,
            Name = report.Name,
            Content = report.Content,
        };
    }

    public void verifyRequest(ReportUpdateRequestDTO report)
    {
        report.Name = verifyFileName(report.Name);
    }

    public void verifyRequest(ReportRequestDTO reportRequestDTO)
    {
        reportRequestDTO.FileName = verifyFileName(reportRequestDTO.FileName);
        reportRequestDTO.Text = verifyContent(reportRequestDTO.Text);
    }

    private string verifyContent(string? content)
    {
        if (string.IsNullOrEmpty(content))
        {
            throw new EmptyPromptException();
        }
        if (content.Length > 1200)
        {
            throw new PromptTooLongException();
        }
        return content;
    }

    private string verifyFileName(string? fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return "Nouveau compte rendu";
        }
        return fileName;
    }
}