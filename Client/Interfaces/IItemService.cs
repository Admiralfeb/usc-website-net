namespace UnitedSystemsCooperative.Web.Client.Interfaces;

public interface IItemService<T>
{
    public Task AddItem(T item);
    public IEnumerable<T> GetFromStore();
    public Task<IEnumerable<T>> GetFromServer();
    public Task UpdateItem(T item);
    public Task DeleteItem(string itemId);
}