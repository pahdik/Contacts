using Contacts.Infrastucture.Extensions;
using Contacts.Application.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddProfiles();

builder.Services.ConfigureDatabaseConnection(builder.Configuration.GetConnectionString("SQLServer"));
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=Index}/{id?}");

app.Run();
  