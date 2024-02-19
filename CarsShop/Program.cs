var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));

builder.Services.AddTransient<IBrendInterface, BrendRepository>();
builder.Services.AddTransient<ICarInterface, CarRepository>();
builder.Services.AddTransient<IOrderInterface, OrderRepository>();
builder.Services.AddTransient<IColorInterface, ColorRepository>();
builder.Services.AddTransient<IImageInterface, ImageRepository>();
builder.Services.AddTransient<IUserInterface, UserRepository>();
builder.Services.AddTransient<IModelInterface, ModelRepository>();
builder.Services.AddTransient<ICategoryInterface, CategoryRepository>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
