using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesFrontEnd.Pages;

public class DownstreamUnauthorizedModel(IHttpClientFactory httpClientFactory) : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task OnGet()
    {
        var client = _httpClientFactory.CreateClient();

        _ = await client.GetAsync("https://localhost:7112/unauthorized");
    }
}
