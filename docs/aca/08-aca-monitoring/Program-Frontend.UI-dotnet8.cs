using Microsoft.ApplicationInsights.Extensibility;
using TasksTracker.WebPortal.Frontend.Ui;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationInsightsTelemetry();
builder.Services.Configure<TelemetryConfiguration>((o) => {
    o.TelemetryInitializers.Add(new AppInsightsTelemetryInitializer());
});

builder.Services.AddRazorPages();

builder.Services.AddDaprClient();

builder.Services.AddHttpClient("BackEndApiExternal", httpClient =>
{
    var backendApiBaseUrlExternalHttp = builder.Configuration.GetValue<string>("BackendApiConfig:BaseUrlExternalHttp");

    if (!string.IsNullOrEmpty(backendApiBaseUrlExternalHttp)) {
        httpClient.BaseAddress = new Uri(backendApiBaseUrlExternalHttp);
    } else {
        throw new("BackendApiConfig:BaseUrlExternalHttp is not defined in App Settings.");
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
