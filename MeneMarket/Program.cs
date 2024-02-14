using System.Text;
using MeneMarket.Brokers.Files;
using MeneMarket.Brokers.Storages;
using MeneMarket.Services.Foundations.Clients;
using MeneMarket.Services.Foundations.Files;
using MeneMarket.Services.Foundations.ImageMetadatas;
using MeneMarket.Services.Foundations.OfferLinks;
using MeneMarket.Services.Foundations.ProductAttributes;
using MeneMarket.Services.Foundations.ProductRequests;
using MeneMarket.Services.Foundations.Products;
using MeneMarket.Services.Foundations.Users;
using MeneMarket.Services.Orchestrations.Images;
using MeneMarket.Services.Orchestrations.Products;
using MeneMarket.Services.Orchestrations.Users;
using MeneMarket.Services.Processings.Files;
using MeneMarket.Services.Processings.Images;
using MeneMarket.Services.Processings.Products;
using MeneMarket.Services.Processings.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standart Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        });

builder.Services.AddAuthorization();
builder.Services.AddDbContext<StorageBroker>();
AddProcessingServices(builder);
AddOrchestrationServices(builder);
AddFoundationServices(builder);
AddBrokers(builder);

static void AddBrokers(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IStorageBroker, StorageBroker>();
    builder.Services.AddTransient<IFileBroker, FileBroker>();
}

static void AddFoundationServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IFileService, FileService>();
    builder.Services.AddTransient<IProductRequestService, ProductRequestService>();
    builder.Services.AddTransient<IClientService, ClientService>();
    builder.Services.AddTransient<IOfferLinkService, OfferLinkService>();
    builder.Services.AddTransient<IUserService, UserService>();
    builder.Services.AddTransient<IProductService, ProductService>();
    builder.Services.AddTransient<IImageMetadataService, ImageMetadataService>();
    builder.Services.AddTransient<IProductAttributeService, ProductAttributeService>();
}

static void AddProcessingServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IFileProcessingService, FileProcessingService>();
    builder.Services.AddTransient<IUserProcessingService, UserProcessingService>();
    builder.Services.AddTransient<IProductProcessingService, ProductProcessingService>();
    builder.Services.AddTransient<IImageMetadataProcessingService, ImageMetadataProcessingService>();
}

static void AddOrchestrationServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IUserOrchestrationService, UserOrchestrationService>();
    builder.Services.AddTransient<IImageOrchestrationService, ImageOrchestrationService>();
    builder.Services.AddTransient<IProductOrchestrationService, ProductOrchestrationService>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseStaticFiles();

app.Run();