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

        public DbSet<PaymentDetail> PaymentDetail { get; set; }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<ProductDetail> ProductDetail { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<Stock> Stock { get; set; }
    }
}
