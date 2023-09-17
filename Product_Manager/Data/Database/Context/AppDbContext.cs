using Microsoft.EntityFrameworkCore;
using Product_Manager.Domain.Models;

namespace Product_Manager.Data.Database.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    { }

    public DbSet<Product> Products { get; set; }
}