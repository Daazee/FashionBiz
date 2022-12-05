using FashionBiz.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FashionBiz.Api.Context
{
    public class FashionContext : DbContext
    {
        public FashionContext(DbContextOptions<FashionContext> options)
            : base(options)
        {

        }
        public DbSet<Company> Company { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<CustomerMeasurement> CustomerMeasurement { get; set; }
    }
}
