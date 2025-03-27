using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace RazorPagesFrontEnd.Pages
{
    public class LoggedErrorModel(ILogger<LoggedErrorModel> logger) : PageModel
    {
        private readonly ILogger _logger = logger;

        public void OnGet()
        {
            using var activity = Instrumentation.ApplicationActivitySource
                .StartActivity("Doing stuff", ActivityKind.Internal);

            _logger.LogError("The world is on fire!");
        }
    }
}
