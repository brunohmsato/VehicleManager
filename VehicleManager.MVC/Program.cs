using VehicleManager.Application.Interfaces;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Infra.Data.DbContext;
using VehicleManager.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new ApplicationDbContext(builder.Configuration));

builder.Services.AddScoped<IFuelService, FuelService>();
builder.Services.AddScoped<IFuelRepository, FuelRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();