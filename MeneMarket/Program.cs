using System.Text;
using MeneMarket.Brokers.Files;
using MeneMarket.Brokers.Storages;
using MeneMarket.Brokers.Tokens;
using MeneMarket.Services.Foundations.BalanceHistorys;
using MeneMarket.Services.Foundations.Clients;
using MeneMarket.Services.Foundations.Comments;
using MeneMarket.Services.Foundations.DonationBoxes;
using MeneMarket.Services.Foundations.Files;
using MeneMarket.Services.Foundations.ImageMetadatas;
using MeneMarket.Services.Foundations.OfferLinks;
using MeneMarket.Services.Foundations.ProductAttributes;
using MeneMarket.Services.Foundations.ProductRequests;
using MeneMarket.Services.Foundations.Products;
using MeneMarket.Services.Foundations.Tokens;
using MeneMarket.Services.Foundations.Users;
using MeneMarket.Services.Orchestrations.Clients;
using MeneMarket.Services.Orchestrations.DonationBoxes;
using MeneMarket.Services.Orchestrations.Images;
using MeneMarket.Services.Orchestrations.ProductRequests;
using MeneMarket.Services.Orchestrations.Users;
using MeneMarket.Services.Processings.BalanceHistorys;
using MeneMarket.Services.Processings.DonationBoxes;
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6AD2EF4v89d4v9dse98df784DE-Ada98f4as894B2C-48sd4v98s7v98sd78dg8d49g"),
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
    builder.Services.AddTransient<ITokenBroker, TokenBroker>();
}

static void AddFoundationServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<ICommentService, CommentService>();
    builder.Services.AddTransient<IBalanceHistoryService, BalanceHistoryService>();
    builder.Services.AddTransient<IClientService, ClientService>();
    builder.Services.AddTransient<IDonationBoxService, DonationBoxService>();
    builder.Services.AddTransient<IFileService, FileService>();
    builder.Services.AddTransient<IImageMetadataService, ImageMetadataService>();
    builder.Services.AddTransient<IOfferLinkService, OfferLinkService>();
    builder.Services.AddTransient<IProductAttributeService, ProductAttributeService>();
    builder.Services.AddTransient<IProductRequestService, ProductRequestService>();
    builder.Services.AddTransient<IProductService, ProductService>();
    builder.Services.AddTransient<ITokenService, TokenService>();
    builder.Services.AddTransient<IUserService, UserService>();
}

static void AddProcessingServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IDonationBoxProcessingService, DonationBoxProcessingService>();
    builder.Services.AddTransient<IBalanceHistoryProcessingService, BalanceHistoryProcessingService>();
    builder.Services.AddTransient<IFileProcessingService, FileProcessingService>();
    builder.Services.AddTransient<IUserProcessingService, UserProcessingService>();
    builder.Services.AddTransient<IProductProcessingService, ProductProcessingService>();
    builder.Services.AddTransient<IImageMetadataProcessingService, ImageMetadataProcessingService>();
}

static void AddOrchestrationServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IClientOrchestrationService,  ClientOrchestrationService>();
    builder.Services.AddTransient<IDonationBoxOrchestrationService, DonationBoxOrchestrationService>();
    builder.Services.AddTransient<IProductRequestOrchestrationService, ProductRequestOrchestrationService>();
    builder.Services.AddTransient<IUserOrchestrationService, UserOrchestrationService>();
    builder.Services.AddTransient<IUserSecurityOrchestrationService, UserSecurityOrchestrationService>();
    builder.Services.AddTransient<IImageOrchestrationService, ImageOrchestrationService>();
}

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();

app.Run();