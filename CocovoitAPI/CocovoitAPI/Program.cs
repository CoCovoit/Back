using CocovoitAPI.Application.UseCase;
using CocovoitAPI.Business.Repository;
using CocovoitAPI.RestController.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CocovoitAPI.Application.Bus;
using CocovoitAPI.Infrastructure.Configuration;
using CocovoitAPI.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);

// CORS - Autoriser tout
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

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

builder.Services.AddDbContext<ApplicationDbContext>(options=>
     //options.UseMySql("Server=localhost;Database=cocovoit;User=root;Password=cocovoit;",
     //    new MySqlServerVersion(new Version(8, 0, 21)))
    options.UseMySql("Server=mysql;Database=cocovoit;User=root;Password=cocovoit;",
           new MySqlServerVersion(new Version(8, 0, 21)),
           mysqlOptions =>
           {
               mysqlOptions.EnableRetryOnFailure(
                     maxRetryCount: 10, // Nombre maximum de tentatives
                     maxRetryDelay: TimeSpan.FromSeconds(10), // Délai maximal entre les tentatives
                     errorNumbersToAdd: null // Ajouter des codes d'erreur spécifiques si nécessaire
               );
           })
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine)
);

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

// Utiliser la politique CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();