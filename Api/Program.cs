using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using OidcApiAuthorization;

namespace UnitedSystemsCooperative.Web.Api;

public class Program
{
    public static void Main()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(x => x.AddOidcApiAuthorization())
            .Build();

        host.Run();
    }
}