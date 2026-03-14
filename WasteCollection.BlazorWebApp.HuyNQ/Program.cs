using WasteCollection.BlazorWebApp.HuyNQ.Components;
using WasteCollection.Services.HuyNQ;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ICollectorAssignmentsHuyNqService, CollectorAssignmentsHuyNqService>();
builder.Services.AddScoped<ReportsHuyNqService>();
builder.Services.AddScoped<SystemUserAccountService>();

builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", opts =>
    {
        long expireTime = long.Parse(configuration["Authentication:CookieAuthTTL"] ?? throw new InvalidDataException("Invalid Authentication:CookieAuthTTL variable environment."));
        opts.ExpireTimeSpan = TimeSpan.FromMilliseconds(expireTime);
        opts.SlidingExpiration = true;
        opts.LoginPath = "/login";
        opts.AccessDeniedPath = "/login";
    });
builder.Services.AddAuthorization();

builder.Services.AddHttpContextAccessor();

// builder.Services.AddAntiforgery();

var assemblyService = typeof(IAssemblyReference).Assembly;
// Add AutoMapper profiles
builder.Services.AddAutoMapper(cfg => { }, assemblyService);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
