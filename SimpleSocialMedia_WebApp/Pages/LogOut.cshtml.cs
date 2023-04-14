using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleSocialMedia_WebApp.Pages
{
    public class LogOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (Request.Cookies["LoginToken"] != null)
            {
                Response.Cookies.Delete("LoginToken");
            }
            return Redirect("/Index");
        }
    }
}
