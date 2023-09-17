using Microsoft.EntityFrameworkCore;

namespace Product_Manager.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    { }

    public DbSet<> Type { get; set; }
}