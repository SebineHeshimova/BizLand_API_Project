using BizLand.API.MappingProfiles;
using BizLand.Business.DTOs.ProfessionDTOs;
using BizLand.Business.Services.Implementations;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Repositories.Interfaces;
using BizLand.Data.DAL;
using BizLand.Data.Repositories.Implementations;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IProfessionRepository, ProfessionRepository>();
builder.Services.AddScoped<IProfessionService, ProfessionService>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IFeatureService, FeatureService>();

builder.Services.AddControllers().AddFluentValidation(option =>
{
    option.RegisterValidatorsFromAssembly(typeof(CreateProfessionDTOValidator).Assembly);
});
builder.Services.AddAutoMapper(typeof(MapProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BizLandDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-RME1C3K;Database=BizLandDb;Trusted_Connection=True;");
});
var app = builder.Build();

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
