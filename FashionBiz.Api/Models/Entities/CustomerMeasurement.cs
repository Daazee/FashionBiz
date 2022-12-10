namespace FashionBiz.Api.Models.Entities
{
    public class CustomerMeasurement
    {
        public long CustomerMeasurementId { get; set; }
        public string GarmentType { get; set; }
        public string Generalsize { get; set; } //large, medium, small
        public string MeasurementType { get; set; }
        public int Chest { get; set; }
        public int Collar { get; set; }
        public int Arm { get; set; }
        public int Back { get; set; }
        public int Waist { get; set; }
        public long CustomerId { get; set; }
    }
}
