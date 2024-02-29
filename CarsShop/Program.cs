using AdminLab.Ants;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IBrendService, BrendService>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IColorService, ColorService>();
builder.Services.AddTransient<IAuthService, AuthService>();

var mapConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

builder.Services.AddSingleton(mapConfig.CreateMapper());
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddAuthentication()
    .AddCookie("Admin", config =>
    {
        config.LoginPath = "/admin/auth/login";
    })
    .AddCookie("User", config =>
    {
        config.LoginPath = "/auth/login";
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
       name: "admin",
          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

LazyCat<AppDbContext>.InitializeLazyAdmin(app);

app.Run();