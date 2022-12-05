using FashionBiz.Api.Context;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;

namespace FashionBiz.Api.DAL
{
    public class CustomerMeasurementRepository : BaseRepository<CustomerMeasurement>, ICustomerMeasurementRepository
    {
        private FashionContext context;
        public CustomerMeasurementRepository(FashionContext context) : base(context)
        {
            this.context = context;
        }
    }
}
