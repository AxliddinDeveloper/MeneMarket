using MeneMarket.Brokers.Files;
using MeneMarket.Brokers.Storages;
using MeneMarket.Brokers.Tokens;
using MeneMarket.Services.Foundations.BalanceHistorys;
using MeneMarket.Services.Foundations.Clients;
using MeneMarket.Services.Foundations.Comments;
using MeneMarket.Services.Foundations.DonatedUsers;
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
using MeneMarket.Services.Orchestrations.Products;
using MeneMarket.Services.Orchestrations.Users;
using MeneMarket.Services.Processings.BalanceHistorys;
using MeneMarket.Services.Processings.DonationBoxes;
using MeneMarket.Services.Processings.Files;
using MeneMarket.Services.Processings.Images;
using MeneMarket.Services.Processings.Products;
using MeneMarket.Services.Processings.Users;

namespace MeneMarket
{
    public class RegisterServices
    {
        public void AddBrokers(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IStorageBroker, StorageBroker>();
            builder.Services.AddTransient<IFileBroker, FileBroker>();
            builder.Services.AddTransient<ITokenBroker, TokenBroker>();
        }

        public void AddFoundationServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IDonatedUserService, DonatedUserService>();
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

        public void AddProcessingServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IDonationBoxProcessingService, DonationBoxProcessingService>();
            builder.Services.AddTransient<IBalanceHistoryProcessingService, BalanceHistoryProcessingService>();
            builder.Services.AddTransient<IFileProcessingService, FileProcessingService>();
            builder.Services.AddTransient<IUserProcessingService, UserProcessingService>();
            builder.Services.AddTransient<IProductProcessingService, ProductProcessingService>();
            builder.Services.AddTransient<IImageMetadataProcessingService, ImageMetadataProcessingService>();
        }

        public void AddOrchestrationServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IProductOrchestrationService, ProductOrchestrationService>();
            builder.Services.AddTransient<IClientOrchestrationService, ClientOrchestrationService>();
            builder.Services.AddTransient<IDonationBoxOrchestrationService, DonationBoxOrchestrationService>();
            builder.Services.AddTransient<IProductRequestOrchestrationService, ProductRequestOrchestrationService>();
            builder.Services.AddTransient<IUserOrchestrationService, UserOrchestrationService>();
            builder.Services.AddTransient<IUserSecurityOrchestrationService, UserSecurityOrchestrationService>();
            builder.Services.AddTransient<IImageOrchestrationService, ImageOrchestrationService>();
        }
    }
}
