using FashionBiz.Api.Models.Entities;

namespace FashionBiz.Api.Repository
{
    public interface ICustomerMeasurementRepository : IBaseRepository<CustomerMeasurement>
    {
        Task<IEnumerable<CustomerMeasurement>> GetMeasurementByCustomerIdAsync(long customerId);
    }
}
