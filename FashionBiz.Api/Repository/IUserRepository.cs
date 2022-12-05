using FashionBiz.Api.Models.Entities;

namespace FashionBiz.Api.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUsername(string username);
    }
}
