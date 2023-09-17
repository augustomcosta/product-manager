using Microsoft.AspNetCore.Mvc;
using Product_Manager.Domain.Models;
using Product_Manager.Domain.Repositories;

namespace Product_Manager.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;
    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _repository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _repository.GetById(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _repository.Create(product);
        return Ok(product);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(Product product, int id)
    {
        await _repository.Update(product, id);
        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedProduct = await _repository.Delete(id);
        return Ok(deletedProduct);
    }
}