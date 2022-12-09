using FashionBiz.App.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashionBiz.App.Pages.User
{
    public class NewUserModel : PageModel
    {
        IConfiguration Configuration;
        public NewUserModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [BindProperty]
        public long UserId { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if(Password != ConfirmPassword)
                {
                    ViewData["Message"] = "Password does not match";
                    return Page();
                }
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/user/";
                string hashPassword =  Utility.HashPassword(Password);
                object user = new
                {
                    //CustomerId = 0,
                    Username = Username,
                    Password = hashPassword
                };

                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(user, ApiRequest.Verbs.POST, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    //userListViewModels = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<UserListViewModel>>(responseString);
                    //ViewData["Message"] = "Customer Created Successfully";
                }

            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return Page();
            }

            return RedirectToPage("/User/Users");
        }
    }
}
