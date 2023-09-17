using Microsoft.EntityFrameworkCore;
using Product_Manager.Data.Database.Context;
using Product_Manager.Domain.Models;
using Product_Manager.Domain.Repositories;

namespace Product_Manager.Data.RepositoriesImpl;

public class ProductRepositoryImpl : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepositoryImpl(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Product> Create(Product product)
    {
        if (product == null)
        {
            throw new ArgumentException("Invalid Product");
        }

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
        
        return product;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var products = await _dbContext.Products.ToListAsync();

        if (products == null)
        {
            throw new Exception("No products found");
        }

        return products;
    }

    public async Task<Product> GetById(int? id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            throw new Exception($"Product with id {id} not found");
        }

        return product;
    }

    public async Task<Product> Update(Product product, int? id)
    {
        var productById = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productById == null)
        {
            throw new Exception($"Product with id {id} not found");
        }

        productById.UpdateFrom(product);
        _dbContext.Products.Update(productById);
        await _dbContext.SaveChangesAsync();
        
        return productById;
    }

    public async Task<Product> Delete(int? id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            throw new Exception($"Product with id {id} not found");
        }

        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }
}