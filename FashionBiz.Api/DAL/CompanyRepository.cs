using FashionBiz.Api.Context;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;

namespace FashionBiz.Api.DAL
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private FashionContext context;
        public CompanyRepository(FashionContext context) : base(context)
        {
            this.context = context;
        }
    }
}
