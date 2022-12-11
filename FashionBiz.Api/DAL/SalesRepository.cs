using FashionBiz.Api.Context;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;

namespace FashionBiz.Api.DAL
{
    public class SalesRepository : BaseRepository<Sales>, ISalesRepository
    {
        private FashionContext context;
        public SalesRepository(FashionContext context) : base(context)
        {
            this.context = context;
        }
    }
}
