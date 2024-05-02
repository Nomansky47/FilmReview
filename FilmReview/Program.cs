using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using FilmReview.Data;
using Microsoft.EntityFrameworkCore;
using NomaniusMVC;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorise(options =>{options.Immediate = true;}).AddBootstrapProviders().AddFontAwesomeIcons();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//DbInitializer.AddMySqlContext<MyContext>(builder.Services, connectionString);
DbInitializer.AddSqlServerContext<MyContext>(builder.Services, connectionString);
var app = builder.Build();
DbInitializer.CreateDbIfNotExists<MyContext>(app);
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomePage}/{id?}");

app.MapBlazorHub();

app.Run();