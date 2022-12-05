namespace FashionBiz.Api.Models.Entities
{
    public class Company
    {
        public long CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public byte[] Logo { get; set; }
        public string Flag { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
