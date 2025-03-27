using OpenTelemetry;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder.AddElasticOpenTelemetry(b => b
    .WithTracing(t => t.AddSource("MyAppInstrumentation")
        .AddAspNetCoreInstrumentation(o => o.EnrichWithException = (activity, ex) =>
        {
            activity.AddException(ex);

            if (ex.Source is not null)
            {
                activity.SetTag("exception.source", ex.Source);
            }
        })));

builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
