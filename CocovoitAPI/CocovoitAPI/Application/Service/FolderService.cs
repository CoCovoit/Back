using CocovoitAPI.Application.DTO.@in.Folder;
using CocovoitAPI.Application.DTO.@out;
using CocovoitAPI.Domain.exception;
using CocovoitAPI.Domain.models;
using CocovoitAPI.Domain.repositories;

namespace CocovoitAPI.Application;

public class FolderService
{
    private readonly IFolderRepository _folderRepository;
    private readonly IReportRepository _reportReporitory;
    public FolderService(IFolderRepository folderRepository, IReportRepository reportReporitory)
    {
        _folderRepository = folderRepository;
        _reportReporitory = reportReporitory;
    }

    public async Task<List<Folder>> findAllByUtilisateur(long idUtilisateur)
    {
        return await _folderRepository.findAllByIdUtilisateur(idUtilisateur);
    }

    public async Task<List<ReportResponseDTO>> getReports(long id)
    {
        List<Report> reports = await _reportReporitory.findAllByFolder(id);
        return reports.Select(report => new ReportResponseDTO
        {
            Id = report.Id,
            Name = report.Name,
            Content = report.Content
        }).ToList(); ;
    }

    public async Task<Folder> save(Folder folder)
    {
        return await _folderRepository.create(folder);
    }

    public async Task delete(long id)
    {
        List<Report> reports = await _reportReporitory.findAllByFolder(id);
        if (reports.Count > 0)
        {
            throw new FolderNotEmptyException();
        }
        await _folderRepository.delete(id);
    }

    public async Task<bool> exists(long id)
    {
        return await _folderRepository.exists(id);
    }

    public async Task<Folder> update(Folder folder)
    {
        if (await _folderRepository.exists(folder.Id))
        {
            return await _folderRepository.update(folder);
        }
        else
        {
            throw new FolderNotFoundException();
        }
    }
}