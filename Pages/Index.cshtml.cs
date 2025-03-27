using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace RazorPagesFrontEnd.Pages;

public class IndexModel : PageModel
{
    public async Task OnGet()
    {
        using var activity = Instrumentation.ApplicationActivitySource
            .StartActivity("Doing stuff", ActivityKind.Internal);

        await Task.Delay(100);

        activity?.SetTag("My label", "A value");
    }
}

public static class Instrumentation
{
    public static readonly ActivitySource ApplicationActivitySource = new("MyAppInstrumentation");
}
