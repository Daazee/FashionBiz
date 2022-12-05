using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashionBiz.App.Pages.Security
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public LoginViewModel? LoginViewModel { get; set; }
        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
               // return null;
            }

           // string username = formCollection["username"].ToString();

            //if (Customer != null) _context.Customer.Add(Customer);
            //await _context.SaveChangesAsync();
            await Task.FromResult(1);
            return RedirectToPage("/Customer/List");
            //return new JsonResult("working");
        }

    }

    public class LoginViewModel
    {
        public string username { get; set; }
    }


}
