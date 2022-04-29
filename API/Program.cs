using API.Extensions;
using Application.Features.Peoples;
using FluentValidation.AspNetCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddFluentValidation(f =>
    {
        f.RegisterValidatorsFromAssemblyContaining<CreatePeople.CreatePeopleCommand>();
        f.DisableDataAnnotationsValidation = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MongoDB Database
builder.Services.AddDatabaseServices(builder.Configuration);

builder.Services.AddMediatR(typeof(GetAllPeople.GetAllPeopleQuery).Assembly);

//Dependency Injection
builder.Services.AddApplicationServices();

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