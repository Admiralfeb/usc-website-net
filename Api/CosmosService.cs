using System;
using Microsoft.Azure.Cosmos;

namespace UnitedSystemsCooperative.Web.Api;

public class CosmosService
{
    private static Lazy<CosmosClient> lazyClient = new();
    private static CosmosClient cosmosClient => lazyClient.Value;

    private static CosmosClient InitializeCosmosClient()
    {
        var connectionString = string.Empty;

        return new CosmosClient(connectionString);
    }
}