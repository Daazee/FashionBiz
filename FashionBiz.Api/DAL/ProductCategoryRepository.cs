using FashionBiz.Api.Context;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;

namespace FashionBiz.Api.DAL
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        private FashionContext context;
        public ProductCategoryRepository(FashionContext context) : base(context)
        {
            this.context = context;
        }
    }
}
