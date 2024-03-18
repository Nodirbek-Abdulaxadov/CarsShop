namespace CarsShop.Infrastucture;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<User>(options)
{
    public DbSet<Brend> Brends { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Order> Orders { get; set; }
}