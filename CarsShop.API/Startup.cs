namespace CarsShop.API;

public static class Startup
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB"));
        });

        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapperProfile());
        });

        builder.Services.AddSingleton(mapperConfig.CreateMapper());

        builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();
        builder.Services.AddScoped<IValidator<Brend>, BrendValidator>();
        builder.Services.AddScoped<IValidator<Car>, CarValidator>();
        builder.Services.AddScoped<IValidator<Color>, ColorValidator>();

        builder.Services.AddTransient<ICategoryService, CategoryService>();
    }

    public static void ConfigureMiddlewares(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Category}/{action=Index}/{id?}"
            );
        app.MapControllers();

        //LazyCat<AppDbContext>.InitializeLazyAdmin(app);
    }
}