using CaseTracker.DataAccessLayer.DataContext;
using CaseTracker.DataAccessLayer.DataServices;
using CaseTracker.DataAccessLayer.IDataServices;
using CaseTracker.DataAccessLayer.Models;
using CaseTracker.MiddlewareErrorHandling;
using CaseTracker.Service.DataLogics.IServices;
using CaseTracker.Service.DataLogics.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration
            .GetConnectionString("CaseTracker")));
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));
#region
builder.Services.AddSingleton<IFileStorageService, FileStorageService>();
builder.Services.AddScoped<IConsultantRepo, ConsultantRepo>();
builder.Services.AddScoped<IConsultantService, ConsultantService>();
builder.Services.AddScoped<IRepoConsultant, RepoConsultant>();
builder.Services.AddScoped<INextStepRepo, NextStepRepo>();
builder.Services.AddScoped<ICommunicationUpdateRepo, CommunicationUpdateRepo>();
builder.Services.AddScoped<IAttachmentRepo, AttachmentRepo>();
#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();



app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



app.UseCustomErrorHandling();
app.UseHttpsRedirection();


app.MapControllers();

app.Run();



