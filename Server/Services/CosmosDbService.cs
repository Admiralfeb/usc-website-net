using Microsoft.Azure.Cosmos;
using UnitedSystemsCooperative.Web.Server.Interfaces;

namespace UnitedSystemsCooperative.Web.Server.Services;

public class CosmosDbService : IDatabaseService
{
    private readonly CosmosClient _cosmosClient;

    public CosmosDbService(IConfiguration config)
    {
        var connectionString = config["CosmosConnString"];
        _cosmosClient = new CosmosClient(connectionString);
    }

    public Task InsertItem<T>(string collectionName, T itemToInsert)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateItem<T>(string collectionName, T itemToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task DeleteItem(string collectionName, string id)
    {
        throw new NotImplementedException();
    }

    public Task<T[]> GetItems<T>(string collectionName, string? sortField, SortOrder? sortOrder)
    {
        throw new NotImplementedException();
    }

    public Task<T[]> GetItems<T>(string collectionName, string query, string? sortField, SortOrder? sortOrder)
    {
        throw new NotImplementedException();
    }
}