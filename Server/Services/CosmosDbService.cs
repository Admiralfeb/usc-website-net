using Microsoft.Azure.Cosmos;
using UnitedSystemsCooperative.Web.Server.Interfaces;

namespace UnitedSystemsCooperative.Web.Server.Services;

public class CosmosDbService : IDatabaseService
{
    private readonly CosmosClient _cosmosClient;
    private readonly string _dbId;

    public CosmosDbService(IConfiguration config)
    {
        var connectionString = config["CosmosConnString"];
        _cosmosClient = new CosmosClient(connectionString);
        _dbId = config["DatabaseId"];
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

    public async Task<T[]> GetItemsAsync<T>(string collectionName, string? sortField, SortOrder? sortOrder = SortOrder.Ascending)
    {
        string sqlQueryText = "SELECT * from c";
        if (!string.IsNullOrEmpty(sortField))
        {
            sqlQueryText += $" ORDERBY c.{sortField}";
            var direction = sortOrder switch
            {
                SortOrder.Ascending => "ASC",
                SortOrder.Descending => "DESC",
                _ => throw new ArgumentOutOfRangeException(nameof(sortOrder), sortOrder, null)
            };
            sqlQueryText += $" {direction}";
        }
        var sqlQuery = new QueryDefinition(sqlQueryText);
        var container = _cosmosClient.GetContainer(_dbId, collectionName);

        using var queryResultSetIterator = container.GetItemQueryIterator<T>(sqlQuery);

        List<T> items = new();

        while (queryResultSetIterator.HasMoreResults)
        {
            var currentResult = await queryResultSetIterator.ReadNextAsync();
            items.AddRange(currentResult);
        }

        return items.ToArray();
    }

    public Task<T[]> GetItemsAsync<T>(string collectionName, string query, string? sortField, SortOrder? sortOrder)
    {
        throw new NotImplementedException();
    }
}