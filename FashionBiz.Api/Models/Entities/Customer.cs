namespace FashionBiz.Api.Models.Entities
{
    public class Customer
    {
        public long CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Gender { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public long CompanyId { get; set; }

    }
}
