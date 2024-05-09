using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents(); // enables Razor interactive server side rendering

var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ??
    throw new Exception("GameStoreApiUrl is not set.  Look at cloning the GameStoreApi in the Github and updating this program's appsettings.json.  Since this is local and not anything secret where users secrets needs to be used.");

builder.Services.AddHttpClient<GamesClient>(client => client.BaseAddress = new Uri(gameStoreApiUrl));
builder.Services.AddHttpClient<GenresClient>(client => client.BaseAddress = new Uri(gameStoreApiUrl));

// used before building out the GameStoreApi portion
// builder.Services.AddSingleton<GamesClient>();
// builder.Services.AddSingleton<GenresClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // enables Razor interactive server side rendering

app.Run();
