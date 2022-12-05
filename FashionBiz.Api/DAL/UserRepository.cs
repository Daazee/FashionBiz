using FashionBiz.Api.Context;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;

namespace FashionBiz.Api.DAL
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private FashionContext context;
        public UserRepository(FashionContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<User> GetUserByUsername(string username)
        {
            User user = context.User.Where(c => c.Username == username).FirstOrDefault();
            return await Task.FromResult(user);
        }
    }
}
