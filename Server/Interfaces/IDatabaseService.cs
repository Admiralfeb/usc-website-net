namespace UnitedSystemsCooperative.Web.Server.Interfaces;

public interface IDatabaseService
{
    public Task InsertItem<T>(string collectionName, T itemToInsert);
    public Task<bool> UpdateItem<T>(string collectionName, T itemToUpdate);
    public Task DeleteItem(string collectionName, string id);
    public Task<T[]> GetItems<T>(string collectionName, string? sortField, SortOrder? sortOrder);
    public Task<T[]> GetItems<T>(string collectionName, string query, string? sortField, SortOrder? sortOrder);
}

public enum SortOrder
{
    Ascending = 1,
    Descending = -1
}