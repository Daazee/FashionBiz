using FashionBiz.Api.Context;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;

namespace FashionBiz.Api.DAL
{
    public class ProductDetailRepository : BaseRepository<ProductDetail>, IProductDetailRepository
    {
        private FashionContext context;
        public ProductDetailRepository(FashionContext context) : base(context)
        {
            this.context = context;
        }
    }
}
