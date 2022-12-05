namespace FashionBiz.Api.DTOs.Response
{
    public interface IApiResponse<T>
    {
        string ShortDescription { get; set; }
        T Object { get; set; }
        Dictionary<string, IEnumerable<string>> ValidationErrors { get; set; }
    }
}
