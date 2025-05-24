using CocovoitAPI.Application;
using CocovoitAPI.Application.DTO.@in.Report;
using CocovoitAPI.Domain.exception;
using CocovoitAPI.Domain.models;
using CocovoitAPI.Domain.repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CocovoitAPI.Infrastructure;

public class ReportRepository : ApplicationDbContext, IReportRepository
{
    public DbSet<Report> Reports { get; set; }
    public async Task<Report> save(Report report)
    {
        try
        {
            Reports.Add(report);
            await SaveChangesAsync();
            return report;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Report> findById(long id)
    {
        Report? report = await Reports.FindAsync(id);
        if (report != null)
        {
            return report;
        }
        else
        {
            throw new ReportNotFoundException();
        }
    }

    public async Task<List<Report>> findAllByFolder(long folderId)
    {
        List<Report> reports = await Reports
            .Include(r => r.Folder)
            .Where(r => r.Folder.Id == folderId)
            .ToListAsync();
        return reports;
    }

    public async Task delete(long id)
    {
        Report report = await findById(id);
        Reports.Remove(report);
        await SaveChangesAsync();
    }

    public async Task<bool> exists(long id)
    {
        Report report = await findById(id);
        return await Reports.ContainsAsync(report);
    }

    public async Task<Report> update(Report report)
    {
        Report updatedReport = await findById(report.Id);
        if (!string.IsNullOrWhiteSpace(report.Name))
        {
            updatedReport.Name = report.Name;
        }
        if (!string.IsNullOrWhiteSpace(report.Content))
        {
            updatedReport.Content = report.Content;
        }
        await SaveChangesAsync();
        return updatedReport;
    }
}