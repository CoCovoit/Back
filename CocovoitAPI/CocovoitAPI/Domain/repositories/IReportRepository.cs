using CocovoitAPI.Domain.models;

namespace CocovoitAPI.Domain.repositories;

public interface IReportRepository
{
    public Task<Report> save(Report report);

    public Task<List<Report>> findAllByFolder(long idFolder);

    public Task<Report> findById(long id);

    public Task delete(long id);

    public Task<bool> exists(long id);

    public Task<Report> update(Report report);
}