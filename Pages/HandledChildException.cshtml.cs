using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace RazorPagesFrontEnd.Pages
{
    public class HandledChildExceptionModel : PageModel
    {
        public void OnGet()
        {
            using var activity = Instrumentation.ApplicationActivitySource
                .StartActivity("Doing stuff", ActivityKind.Internal);

            try
            {
                throw new Exception("Something went wrong!");
            }
            catch (Exception ex)
            {
                activity?.AddException(ex);
            }
        }
    }
}
