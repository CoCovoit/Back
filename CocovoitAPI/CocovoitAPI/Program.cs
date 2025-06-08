using CocovoitAPI.Application.UseCase;
using CocovoitAPI.Business.Repository;
using CocovoitAPI.RestController.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CocovoitAPI.Application.Bus;
using CocovoitAPI.Infrastructure.Configuration;
using CocovoitAPI.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<LocalisationMapper>();
builder.Services.AddScoped<ILocalisationUseCase, LocalisationUseCase>();
builder.Services.AddScoped<ILocalisationRepository, LocalisationRepository>();

builder.Services.AddScoped<UtilisateurMapper>();
builder.Services.AddScoped<IUtilisateurUseCase, UtilisateurUseCase>();
builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();

builder.Services.AddScoped<TrajetMapper>();
builder.Services.AddScoped<ITrajetUseCase, TrajetUseCase>();
builder.Services.AddScoped<ITrajetRespository, TrajetRepository>();

builder.Services.AddScoped<ReservationMapper>();
builder.Services.AddScoped<IReservationUseCase, ReservationUseCase>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.Configure<KafkaSettings>(builder.Configuration.GetSection("Kafka"));
builder.Services.AddSingleton<IEventBus, KafkaEventBus>();

builder.Services.AddAutoMapper(typeof(Program));

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