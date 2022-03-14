using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using UnitedSystemsCooperative.Utils.EDCalc.Functions;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Api.Handlers
{
    public class FleetCarriersApi
    {
        private readonly ILogger _logger;

        public FleetCarriersApi(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FleetCarriersApi>();
        }

        [Function("fc")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
            [CosmosDBInput("usc", "fleetCarriers", ConnectionStringSetting = "CosmosConnString")] IEnumerable<FleetCarrier> carriers)
        {
            _logger.LogInformation("FC get request");

            var carrierswLink = carriers.Select(x =>
            {
                x.Link = InaraLinkBuilder.BuildFleetCarrierSearchString(x.Id);
                return x;
            });

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(carrierswLink.ToList());

            return response;
        }
    }
}
