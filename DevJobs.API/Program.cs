using DevJobs.API.AutoMapper;
using DevJobs.Application.Services;
using DevJobs.Core.Entities;
using DevJobs.Core.Interfaces.Repository;
using DevJobs.Core.Interfaces.Service;
using DevJobs.Infrastructure.Persistence.Context;
using DevJobs.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//Inserindo conectionString
var connectionStrings = builder.Configuration.GetConnectionString("DataBase");


builder.Services.AddDbContext<DevJobsContext>(options => 
    options.UseSqlServer(connectionStrings));

//Injeção de Dependência - Repositórios
builder.Services.AddScoped<IRepositoryBase<JobVacancy>, RepositoryBase<JobVacancy>>();
builder.Services.AddScoped<IJobVacancyRepository, JobVacancyRepository>();

//Injeção de Dependência - Services
builder.Services.AddScoped<IServiceBase<JobVacancy>, ServiceBase<JobVacancy>>();

//AutoMapper - todas as confg
builder.Services.AddAutoMapper(typeof(DevJobs_Mapper));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
