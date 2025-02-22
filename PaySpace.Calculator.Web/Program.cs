using PaySpace.Calculator.Web.Services;
using PaySpace.Calculator.Web.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddCalculatorHttpServices();

builder.Services.AddHttpClient<ICalculatorHttpService, CalculatorHttpService>(client =>
{
  client.BaseAddress = new Uri(ApplicationConstants.HttpClients.BASEURI);
});

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
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();