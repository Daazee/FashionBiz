using FashionBiz.Api.Context;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;

namespace FashionBiz.Api.DAL
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private FashionContext context;
        public CustomerRepository(FashionContext context) : base(context)
        {
            this.context = context;
        }
    }
}
