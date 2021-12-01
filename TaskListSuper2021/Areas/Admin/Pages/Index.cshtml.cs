using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskListSuper2021.Areas.Admin.Pages
{
    [Authorize(Policy = "IsAdministrator")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
