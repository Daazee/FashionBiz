namespace FashionBiz.Api.DTOs.Request
{
    public class ProductUpdateRequestDTO
    {
        public long ProductDetailId { get; set; }
        public long ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public string UserId { get; set; }
    }
}
