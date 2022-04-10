using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using OidcApiAuthorization.Abstractions;
using OidcApiAuthorization.Models;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Api.Handlers;

public class AlliesApi
{
    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };

    private readonly IApiAuthorization _apiAuthorization;
    private readonly ILogger _logger;

    public AlliesApi(ILoggerFactory loggerFactory, IApiAuthorization apiAuthorization)
    {
        _logger = loggerFactory.CreateLogger<AlliesApi>();
        _apiAuthorization = apiAuthorization;
    }

    [Function(nameof(GetAllies))]
    public async Task<HttpResponseData> GetAllies(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "allies/get")]
        HttpRequestData req,
        [CosmosDBInput("dev", "allies", ConnectionStringSetting = "CosmosConnString")]
        IEnumerable<Ally> allies)
    {
        _logger.LogInformation("Allies get request");

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(allies.ToList());

        return response;
    }

    [Function(nameof(UpdateAlly))]
    [CosmosDBOutput("usc", "allies", ConnectionStringSetting = "CosmosConnString", CreateIfNotExists = false)]
    public async Task<object> UpdateAlly(
        [HttpTrigger(AuthorizationLevel.User, "post", "allies/update/{id:string}")]
        HttpRequestData req,
        [CosmosDBInput("dev", "allies", ConnectionStringSetting = "CosmosConnString", Id = "{id}")]
        Ally ally)
    {
        HttpResponseData response = null;
        _logger.LogInformation("Ally update request");

        try
        {
            if (ally == null)
            {
                _logger.LogInformation("Ally not found");
                response = req.CreateResponse(HttpStatusCode.NotFound);
                throw new NotFoundException();
            }

            var authResult = await _apiAuthorization.AuthorizeAsync(req.Headers);
            if (authResult.Failed)
            {
                _logger.LogWarning(authResult.FailureReason);
                response = req.CreateResponse(HttpStatusCode.Unauthorized);
                throw new UnauthorizedAccessException();
            }

            var updatedAlly = JsonSerializer.Deserialize<Ally>(req.Body, SerializerOptions);
            return updatedAlly;
        }
        catch (Exception)
        {
            return response ?? req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }

    [Function(nameof(AddAlly))]
    [CosmosDBOutput("usc", "allies", ConnectionStringSetting = "CosmosConnString", CreateIfNotExists = true)]
    public async Task<object> AddAlly(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", "allies/add")]
        HttpRequestData req)
    {
        HttpResponseData response = null;
        _logger.LogInformation("Ally add request");

        try
        {
            var authResult = await _apiAuthorization.AuthorizeAsync(req.Headers);
            if (authResult.Failed)
            {
                _logger.LogWarning(authResult.FailureReason);
                response = req.CreateResponse(HttpStatusCode.Unauthorized);
                throw new UnauthorizedAccessException();
            }

            var updatedAlly = JsonSerializer.Deserialize<Ally>(req.Body, SerializerOptions);
            return updatedAlly;
        }
        catch (Exception)
        {
            return response ?? req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }

    [Function(nameof(DeleteAlly))]
    public async Task<HttpResponseData> DeleteAlly(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", "allies/delete/{id:string}")]
        HttpRequestData req)
    {
        throw new NotImplementedException();
    }
}