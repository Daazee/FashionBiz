using FashionBiz.App.Utilities;
using FashionBiz.App.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashionBiz.App.Pages.User
{
    public class UsersModel : PageModel
    {
        public IEnumerable<UserListViewModel> userListViewModels { get; set; }

        public IEnumerable<UsersModel> usersModel = null;

        public long UserId { get; set; }
        public string Username { get; set; }
        public async Task OnGet()
        {
            try
            {
                string url = "http://localhost:5029/api/user/";
                ApiRequest apiRequest = new ApiRequest();
                var response = await apiRequest.MakeHttpClientRequest(url, null, ApiRequest.Verbs.GET, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<DefaultApiResponse<IEnumerable<UserListViewModel>>>(responseString);
                    usersModel = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<UsersModel>>(responseString);
                    //userLstModels = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ListModel>>(responseString);
                    //if (result.Object != null)
                    //{
                    //    statement = result.Object.ToList();
                    //    return statement;
                    //}
                    //else
                    //    return statement;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
