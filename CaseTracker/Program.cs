using CaseTracker.DataAccessLayer.DataContext;
using CaseTracker.DataAccessLayer.DataServices;
using CaseTracker.DataAccessLayer.IDataServices;
using CaseTracker.DataAccessLayer.Models;
using CaseTracker.MiddlewareErrorHandling;
using CaseTracker.Service.Common;
using CaseTracker.Service.DataLogics.IServices;
using CaseTracker.Service.DataLogics.Services;
using CaseTracker.Service.JwtTokenHandler;
using CaseTracker.Service.JwtTokenHandler.JwtService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
       .ConfigureApiBehaviorOptions(options =>
       {
           options.InvalidModelStateResponseFactory = context =>
           {
               var errors = context.ModelState
                   .Where(e => e.Value?.Errors.Count > 0)
                   .ToDictionary(
                       kvp => kvp.Key,
                       kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                   );

               var result = new
               {
                   isSuccess = false,
                   message = Constants.EnterData,
                   data = (object?)null,
                   errors
               };

               return new BadRequestObjectResult(result);
           };
       });
builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration
            .GetConnectionString("CaseTracker")));

var jwtSecretKey = builder.Configuration["AuthKey:SecretKey"];
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateIssuerSigningKey = true,
                       //ValidIssuer = issuer,
                       //ValidAudience = audience,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey))
                   };
               });
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
});
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
builder.Services.AddScoped<IAuthRepo, AuthRepo>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtAuthenticateService, JwtAuthenticateService>();
builder.Services.AddScoped<IJwtParams, JwtParams>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<INotificationRepo, NotificationRepo>();
#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.UseCustomErrorHandling();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});





//app.MapControllers();

app.Run();



