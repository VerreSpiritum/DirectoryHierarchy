using GeekForLess;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<GeekForLessContext>(options => options.UseNpgsql(connection));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    //endpoints.MapControllerRoute(
    //    name: "second-page",
    //    pattern: "SecondPage",
    //    defaults: new { controller = "Home", action = "SecondPage" });
    //endpoints.MapControllerRoute(
    //    name: "in-resources",
    //    pattern: "InResources",
    //    defaults: new { controller = "Home", action = "InResources" });

});

app.Run();
