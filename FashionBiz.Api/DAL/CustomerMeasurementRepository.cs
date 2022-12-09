using FashionBiz.Api.Context;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace FashionBiz.Api.DAL
{
    public class CustomerMeasurementRepository : BaseRepository<CustomerMeasurement>, ICustomerMeasurementRepository
    {
        private FashionContext context;
        public CustomerMeasurementRepository(FashionContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CustomerMeasurement>> GetMeasurementByCustomerIdAsync(long customerId)
        {
            var result = await context.CustomerMeasurement.Where(c => c.CustomerId == customerId).ToListAsync();
            return result;
        }
    }
}
