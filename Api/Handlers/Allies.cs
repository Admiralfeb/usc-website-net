using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Api;

public class AlliesApi
{
    private readonly ILogger _logger;

    public AlliesApi(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<AlliesApi>();
    }

    [Function("allies")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
        [CosmosDBInput("usc", "allies", ConnectionStringSetting = "CosmosConnString")] IEnumerable<Ally> allies)
    {
        _logger.LogInformation("Allies get request");

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(allies.ToList());

        return response;
    }
}