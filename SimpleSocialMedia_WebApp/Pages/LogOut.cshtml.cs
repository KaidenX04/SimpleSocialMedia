using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleSocialMedia_WebApp.Pages
{
    public class LogOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (Request.Cookies["Username"] != null)
            {
                Response.Cookies.Delete("Username");
            }
            if (Request.Cookies["Password"] != null)
            {
                Response.Cookies.Delete("Password");
            }
            return Redirect("/Index");
        }
    }
}
