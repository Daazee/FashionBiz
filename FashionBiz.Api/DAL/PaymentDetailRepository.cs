using FashionBiz.Api.Context;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;

namespace FashionBiz.Api.DAL
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        private FashionContext context;
        public StockRepository(FashionContext context) : base(context)
        {
            this.context = context;
        }
    }
}
