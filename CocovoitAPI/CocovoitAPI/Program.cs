using CocovoitAPI.Application;
using CocovoitAPI.Application.mappers;
using CocovoitAPI.Application.Service;
using CocovoitAPI.Domain.repositories;
using CocovoitAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddSingleton<OpenAiService>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<ReportService>();
builder.Services.AddScoped<ReportMapper>();

builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddScoped<FolderService>();
builder.Services.AddScoped<FolderMapper>();

builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IFolderTagReporitory, FolderTagRepository>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<TagMapper>();
builder.Services.AddScoped<FolderTagMapper>();

builder.Services.AddHostedService<MigrationService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();