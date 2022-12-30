using System.ComponentModel.DataAnnotations;

namespace FashionBiz.Api.Models.Entities
{
    public class ProductCategory
    {
        [Key]
        public long ProductCategoryId { get; set; }

        [Required]
        [Display(Name = "Product Category")]
        public string ProductCategoryName { get; set; }

        public string Flag { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<ProductDetail>? ProductDetail { get; set; }

    }
}
