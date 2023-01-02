namespace FashionBiz.Api.DTOs.Request
{
    public class ProductCategoryUpdateRequestDTO
    {
        public long ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string UserId { get; set; }
    }
}
