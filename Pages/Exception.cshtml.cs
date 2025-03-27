using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesFrontEnd.Pages
{
    public class ExceptionModel : PageModel
    {
        public void OnGet()
        {
            throw new Exception("Oh no!!!");
        }
    }
}
