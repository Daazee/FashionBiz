using FashionBiz.Api.Context;
using FashionBiz.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace FashionBiz.Api.DAL
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private FashionContext context;

        public BaseRepository(FashionContext _context)
        {
            context = _context;
        }
        public async Task<T> GetItem(long id)
        {
            var model = await context.Set<T>().FindAsync(id);
            return model;
        }

        // gets list of items async
        public async Task<IEnumerable<T>> GetItems()
        {
            var result = await context.Set<T>().ToListAsync();
            return result;
        }


        public async Task<T> AddItem(T item)
        {
            context.Set<T>().Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        // updates an entity in a set
        public async Task<T> UpdateItem(T item)
        {
            context.Entry<T>(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return item;
        }

        // removes an entity in a set
        public async Task<T> RemoveItem(int id)
        {
            var query = await context.Set<T>().FindAsync(id);
            if (query != null)
            {
                context.Set<T>().Remove(query);
                await context.SaveChangesAsync();
            }
            return query;
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
