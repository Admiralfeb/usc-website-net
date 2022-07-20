namespace UnitedSystemsCooperative.Web.Client.Services;

public class ApiService
{
    private IHttpClientFactory _clientFactory;

    public ApiService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    /// <summary>
    /// Gets the HttpClient. Defaults to secure/authenticated client.
    /// </summary>
    /// <param name="isSecure">Whether should be secure or not.</param>
    /// <returns></returns>
    public HttpClient GetHttpClient(bool isSecure = true)
    {
        return isSecure switch
        {
            false => _clientFactory.CreateClient(Constants.NoAuthHttpClientName),
            _ => _clientFactory.CreateClient(Constants.DefaultHttpClientName)
        };
    }
}