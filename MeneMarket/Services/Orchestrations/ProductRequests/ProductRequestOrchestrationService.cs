using MeneMarket.Models.Foundations.Clients;
using MeneMarket.Models.Foundations.DonationBoxes;
using MeneMarket.Models.Foundations.OfferLinks;
using MeneMarket.Models.Foundations.ProductRequests;
using MeneMarket.Services.Foundations.Clients;
using MeneMarket.Services.Foundations.OfferLinks;
using MeneMarket.Services.Foundations.ProductRequests;
using MeneMarket.Services.Orchestrations.DonationBoxes;
using MeneMarket.Services.Processings.DonationBoxes;

namespace MeneMarket.Services.Orchestrations.ProductRequests
{
    public class ProductRequestOrchestrationService : IProductRequestOrchestrationService
    {
        private readonly IProductRequestService productRequestService;
        private readonly IClientService clientService;
        private readonly IDonationBoxOrchestrationService donationBoxOrchestrationService;
        private readonly IDonationBoxProcessingService donationBoxProcessingService;
        private readonly IOfferLinkService offerLinkService;

        public ProductRequestOrchestrationService(
            IProductRequestService productRequestService, 
            IClientService clientService, 
            IDonationBoxOrchestrationService donationBoxOrchestrationService, 
            IDonationBoxProcessingService donationBoxProcessingService, 
            IOfferLinkService offerLinkService)
        {
            this.productRequestService = productRequestService;
            this.clientService = clientService;
            this.donationBoxOrchestrationService = donationBoxOrchestrationService;
            this.donationBoxProcessingService = donationBoxProcessingService;
            this.offerLinkService = offerLinkService;
        }

        public async ValueTask<ProductRequest> AddProductRequestAsync(ProductRequest productRequest)
        {
            IQueryable<Client> allClients = 
                this.clientService.RetrieveAllClients();

            var client = allClients.FirstOrDefault(c => 
                c.IpAddress == productRequest.IpAddress);

            OfferLink offerLink =
                await  this.offerLinkService.RetrieveOfferLinkByIdAsync(client.OfferLinkId);

            if (client != null && offerLink.ProductId == productRequest.ProductId)
            {
                client.StatusType = StatusType.Accepted;

                await this.clientService.ModifyClientAsync(client);
            }

            productRequest.Status =
                ProductRequestStatusType.Accepted;

            return await this.productRequestService.AddProductRequestAsync(productRequest);
        }

        public IQueryable<ProductRequest> RetrieveAllProductRequests() =>
            this.productRequestService.RetrieveAllProductRequests();

        public async ValueTask<ProductRequest> RetrieveProductRequestByIdAsync(Guid id) =>
            await this.productRequestService.RetrieveProductRequestByIdAsync(id);

        public async ValueTask<ProductRequest> ModifyProductRequestAsync(ProductRequest productRequest)
        {
            bool outbalance = true;

            IQueryable<Client> allClients =
                this.clientService.RetrieveAllClients();

            var selectedProductRequest = 
                await this.RetrieveProductRequestByIdAsync(productRequest.Id);

            var client = allClients.FirstOrDefault(c =>
                c.IpAddress == productRequest.IpAddress);

            var offerLink =
                await this.offerLinkService.RetrieveOfferLinkByIdAsync(client.OfferLinkId);

            if (client != null && 
                selectedProductRequest.Status != productRequest.Status && 
                productRequest.Status == ProductRequestStatusType.Delivered &&
                offerLink.ProductId == productRequest.ProductId)
            {
                client.StatusType.Equals(productRequest.Status.ToString());
                await this.clientService.ModifyClientAsync(client);

                IQueryable<DonationBox> allDonationBoxes = 
                    this.donationBoxProcessingService.RetrieveAllDonationBoxs();

                var selectedDonationBox  = allDonationBoxes.FirstOrDefault(d =>
                d.DonationBoxId == d.DonationBoxId);

                await this.donationBoxOrchestrationService.ModifyDonationBoxAsync(selectedDonationBox, client.OfferLinkId, outbalance = false);

                return await this.productRequestService.ModifyProductRequestAsync(productRequest);
            }
            else if (client != null &&
                selectedProductRequest.Status != productRequest.Status &&
                productRequest.Status == ProductRequestStatusType.CameBack && 
                selectedProductRequest.Status == ProductRequestStatusType.Delivered &&
                offerLink.ProductId == productRequest.ProductId)
            {
                client.StatusType.Equals(productRequest.Status.ToString());
                await this.clientService.ModifyClientAsync(client);
                IQueryable<DonationBox> allDonationBoxes =
                    this.donationBoxOrchestrationService.RetrieveAllDonationBoxes();

                var selectedDonationBox = allDonationBoxes.FirstOrDefault(d =>
                d.DonationBoxId == d.DonationBoxId);

                await this.donationBoxOrchestrationService.ModifyDonationBoxAsync(selectedDonationBox, client.OfferLinkId, outbalance);

                return await this.productRequestService.ModifyProductRequestAsync(productRequest);
            }

            return await this.productRequestService.ModifyProductRequestAsync(productRequest);
        }

        public async ValueTask<ProductRequest> RemoveProductRequestByIdAsync(Guid id) =>
            await this.productRequestService.RemoveProductRequestAsync(id);
    }
}