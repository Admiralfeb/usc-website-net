namespace UnitedSystemsCooperative.Web.Client.Services;

public class ApiService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<ApiService> _logger;

    public ApiService(IHttpClientFactory clientFactory, ILogger<ApiService> logger) =>
        (_clientFactory, _logger) = (clientFactory, logger);

    /// <summary>
    /// Gets the HttpClient. Defaults to secure/authenticated client.
    /// </summary>
    /// <param name="isSecure">Whether should be secure or not.</param>
    /// <returns></returns>
    public HttpClient GetHttpClient(bool isSecure = false)
    {
        _logger.LogDebug("Get HttpClient. Secure: {IsSecure}", isSecure);
        return isSecure switch
        {
            false => _clientFactory.CreateClient(Constants.NoAuthHttpClientName),
            _ => _clientFactory.CreateClient(Constants.DefaultHttpClientName)
        };
    }
}