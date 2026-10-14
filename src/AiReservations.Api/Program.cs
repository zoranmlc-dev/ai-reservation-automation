using AiReservations.Api.ExceptionHandling;
using AiReservations.Application.Reservations.Services;
using AiReservations.Application.Reservations.Repositories;
using AiReservations.Infrastructure.Persistence;
using AiReservations.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AiReservationsDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddExceptionHandler<DomainExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
