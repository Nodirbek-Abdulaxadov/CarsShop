namespace CarsShop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    
    public DbSet<Brend> Brends { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
}