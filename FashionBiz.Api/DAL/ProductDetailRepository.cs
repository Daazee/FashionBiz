using FashionBiz.Api.Context;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;

namespace FashionBiz.Api.DAL
{
    public class PaymentDetailRepository : BaseRepository<PaymentDetail>, IPaymentDetailRepository
    {
        private FashionContext context;
        public PaymentDetailRepository(FashionContext context) : base(context)
        {
            this.context = context;
        }
    }
}
