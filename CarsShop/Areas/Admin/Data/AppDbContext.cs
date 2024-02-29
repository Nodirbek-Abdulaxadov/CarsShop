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
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        User superUser = new()
        {
            Id = 11111111,
            FISH = "Super Admin",
            TelNomer = "+998901234567",
            Password = PasswordHasher.HashPassword("Super.Admin"),
            Address = "Database",
            Role = Role.Admin
        };

        modelBuilder.Entity<User>()
            .HasData(superUser);

        base.OnModelCreating(modelBuilder);
    }
}