using System.ComponentModel.DataAnnotations;

namespace FashionBiz.App.CustomModel
{
    public class ProductCategoryCreateModel
    {
        public long ProductCategoryId { get; set; }

        [Display(Name = "Product Category")]
        public string ProductCategoryName { get; set; }

        public string Flag { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedOn { get; set; }
    }
}
