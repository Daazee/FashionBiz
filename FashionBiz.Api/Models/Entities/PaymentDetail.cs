using System.ComponentModel.DataAnnotations;

namespace FashionBiz.Api.Models.Entities
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        [Display(Name = "Payment Number")]
        public string PaymentNo { get; set; }

        [Required]
        [Display(Name = "Amount Paid")]
        public double SalesAmount { get; set; }
        public string CreatedBy { get; set; }
        public string Flag { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime KeyDate { get; set; }

    }
}
