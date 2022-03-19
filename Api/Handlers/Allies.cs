using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Api.Handlers;

public class AlliesApi
{
    private readonly ILogger _logger;

    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };

    public AlliesApi(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<AlliesApi>();
    }

    [Function("get-allies")]
    public async Task<HttpResponseData> GetAllies(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
        HttpRequestData req,
        [CosmosDBInput("usc", "allies", ConnectionStringSetting = "CosmosConnString")]
        IEnumerable<Ally> allies)
    {
        _logger.LogInformation("Allies get request");

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(allies.ToList());

        return response;
    }

    [Function("update-ally"),
     CosmosDBOutput("usc", "allies", ConnectionStringSetting = "CosmosConnString")]
    public Ally UpdateAlly([HttpTrigger(AuthorizationLevel.User, "post")] HttpRequestData req)
    {
        _logger.LogInformation("Ally update request");

        var ally = JsonSerializer.Deserialize<Ally>(req.Body, SerializerOptions);

        return ally;
    }
}