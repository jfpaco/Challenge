using Challenge.Middleware;
using Challenge.Sinks;
using DataAccess;
using DataAccess.UnitOfWork;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .WriteTo.CustomSink()
        .Enrich.FromLogContext()
        .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ChallengeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

/*
using(var scope = app.Services.CreateScope())
{
    var context= scope.ServiceProvider.GetRequiredService<ChallengeContext>();
    context.Database.Migrate();
}*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseMiddleware(typeof(ExceptionHandling));
app.UseAuthorization();

app.MapControllers();

app.Run();
