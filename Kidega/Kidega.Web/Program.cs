using Kidega.Core.Mappings;
using Kidega.Web.Extensions;
using Kidega.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(MappingConfig)); 

builder.Services.ConfigureDatabase(builder.Configuration)
    .ConfigureIdentity()
    .ConfigureCaches()
    .ConfigureCookies()
    .ConfigureInjections();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseRequestTrackingMiddleware(); // Custom Middleware to log each incoming request, including the URL, HTTP method, request headers, and execution time
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute( // Higher precedence for areas
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
