using Cruddy.Core.Extensions;
using Cruddy.Core.Interfaces;
using CruddyTest.Api.Dtos;
using CruddyTest.Core.Cruddy;
using CruddyTest.Core.Entities;
using CruddyTest.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCruddy(options =>
{
    options.ScanAssembly(typeof(Employee).Assembly);
    options.DefaultDateFormat = "dd/MM/yyyy";
    options.DefaultPageSize = 25;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/api/metadata", (IEntityMetadataProvider provider) =>
{
    var metadata = provider.GetAllMetadata();

    var dto = metadata.Select(m => new EntityMetadataDto
    {
        Name = m.Name,
        ClrType = m.ClrType.FullName ?? m.ClrType.Name,
        Relations = m.Relationships.Select(r => new RelationMetadataDto()
        {
            Name = r.Name,
            TargetEntity = r.TargetEntity,
            ForeignKey = r.ForeignKey,
            IsRequired = r.IsRequired,
            Type = r.Type.ToString()
        }),
        Properties = m.Properties.Select(p => new PropertyMetadataDto
        {
            Name = p.Name,
            Type = p.ClrType.Name,
            DisplayName = p.DisplayName,
            HelpText = p.HelpText,
            IsRequired = p.IsRequired,
            MaxLength = p.MaxLength,
            MinLength = p.MinLength,
            Placeholder = p.Placeholder,
            RequiredMessage = p.RequiredMessage,
        })
    });

    return Results.Ok(dto);
});

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
