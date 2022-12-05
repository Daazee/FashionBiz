namespace FashionBiz.Api.DTOs.Response
{
    public class DefaultApiResponse<T> : IApiResponse<T>
    {
        public DefaultApiResponse()
        {
            ValidationErrors = new Dictionary<string, IEnumerable<string>>();
        }

        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public T Object { get; set; }
        public Dictionary<string, IEnumerable<string>> ValidationErrors { get; set; }
    }
}
