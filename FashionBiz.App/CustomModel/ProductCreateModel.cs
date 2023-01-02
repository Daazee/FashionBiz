using System.ComponentModel.DataAnnotations;

namespace FashionBiz.App.CustomModel
{
    public class ProductDetailCreateModel
    {
        public long ProductDetailId { get; set; }

        [Required]
        public long ProductCategoryId { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Cost Price")]
        public double? CostPrice { get; set; }

        [Required]
        [Display(Name = "Selling Price")]
        public double? SellingPrice { get; set; }

        [Required]
        [Display(Name = "Reorder Level")]
        public int? ReorderLevel { get; set; }

        [Display(Name = "Modified By")]
        public string? UserId { get; set; }

        public string? Flag { get; set; }

        [Display(Name = "Stock Level")]
        public int? StockLevel { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }

    }
}
