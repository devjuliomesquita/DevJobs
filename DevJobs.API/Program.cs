using DevJobs.Infrastructure.Persistence;
using DevJobs.Infrastructure.Persistence.Repositories.Implementations;
using DevJobs.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//Inserindo conectionString
var connectionStrings = builder.Configuration.GetConnectionString("DataBase");

//Injeção de Dependência
builder.Services.AddDbContext<DevJobsContext>(options => 
    options.UseSqlServer(connectionStrings));

builder.Services.AddScoped<IjobVacancyRepository, JobVacancyRepository>();
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
