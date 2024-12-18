using Core.Common.Options;
using Persistence;
using Persistence.SPG;
using Application.SPG;
using Application.SPG.Common.Options;
using Spotify.SPG;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
builder.Services.Configure<FeatureFlagOptions>(builder.Configuration.GetSection(FeatureFlagOptions.SECTION));
builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(DatabaseOptions.SECTION));
builder.Services.Configure<SpotifyClientOptions>(builder.Configuration.GetSection(SpotifyClientOptions.SECTION));

builder.Services.AddApplicationSpg(config);
builder.Services.AddSpotifyIntegrationSPG(config);

builder.Services.AddPersistenceSPG(config);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = false;
    options.ReportApiVersions = false;
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.SetupDatabase();

app.UseCors(builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());

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

Console.WriteLine();
