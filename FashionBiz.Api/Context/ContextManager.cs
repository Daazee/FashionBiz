using Microsoft.EntityFrameworkCore;

namespace FashionBiz.Api.Context
{
    public class ContextManager
    {
        public ContextManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration;

        public static FashionContext GetContext()
        {
            string? connectionstring = Configuration.GetConnectionString("FashionSystemContext");
            var optionsBuilder = new DbContextOptionsBuilder<FashionContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            FashionContext context = new FashionContext(optionsBuilder.Options);
            return context;
        }
    }
}
