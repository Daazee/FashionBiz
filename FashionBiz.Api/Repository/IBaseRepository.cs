namespace FashionBiz.Api.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetItem(long id);
        Task<IEnumerable<T>> GetItems();
        Task<T> AddItem(T item);
        Task<T> UpdateItem(T item);
        Task<T> RemoveItem(int id);
    }
}
