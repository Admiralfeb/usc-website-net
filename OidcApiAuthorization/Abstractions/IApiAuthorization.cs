using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Http;
using OidcApiAuthorization.Models;

namespace OidcApiAuthorization.Abstractions;

public interface IApiAuthorization
{
    Task<ApiAuthorizationResult> AuthorizeAsync(HttpHeadersCollection httpRequestHeaders);

    Task<HealthCheckResult> HealthCheckAsync();
}