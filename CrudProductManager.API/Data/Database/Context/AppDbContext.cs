using CrudProductManager.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudProductManager.API.Data.Database.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    { }

    public DbSet<Product> Products { get; set; }
}