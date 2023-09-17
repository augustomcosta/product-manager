using FluentAssertions;
using Product_Manager.Domain.Models;
using Product_Manager.Domain.Validation;

namespace CrudProjectManager.Tests;

public class ProductTest
{
    [Fact]
    public void CreateProduct_WithNegativeID_ShouldThrowException()
    {
        Action action = () => new Product(-1, "Pão de Forma", "Pão bem gostoso", 14.99m);
        action.Should().Throw<DomainValidationException>().WithMessage("Invalid Id. Id cannot be negative");
    }

    [Fact]
    public void CreateProduct_WithInvalidName_ShouldThrowException()
    {
        Action action = () => new Product(1, "", "Pão bem gostoso", 14.99m);
        action.Should().Throw<DomainValidationException>().WithMessage("Invalid name. Name is required");
    }
    
    [Fact]
    public void CreateProduct_WithNameLengthTooBig_ShouldThrowException()
    {
        string name = new string('A', 51);
        Action action = () => new Product(1, name, "Pão de forma gostoso", 14.99m);
        action.Should().Throw<DomainValidationException>().WithMessage("Invalid name. Name must have a maximum of 50 characters");
    }
    
    [Fact]
    public void CreateProduct_WithNameLengthTooSmall_ShouldThrowException()
    {
        Action action = () => new Product(1, "P", "Pão de forma gostoso", 14.99m);
        action.Should().Throw<DomainValidationException>().WithMessage("Invalid name. Name must have at least 2 characters");
    }
    
    [Fact]
    public void CreateProduct_WithInvalidDescription_ShouldThrowException()
    {
        Action action = () => new Product(1, "Pão de Forma", "", 14.99m);
        action.Should().Throw<DomainValidationException>().WithMessage("Invalid description. Description is required");
    }
    
    [Fact]
    public void CreateProduct_WithDescriptionLengthTooBig_ShouldThrowException()
    {
        string description = new string('A', 201);
        Action action = () => new Product(1, "Pão de Forma", description, 14.99m);
        action.Should().Throw<DomainValidationException>().WithMessage("Invalid description. Description must have a maximum of 200 characters");
    }
    
    [Fact]
    public void CreateProduct_WithDescriptionLengthTooSmall_ShouldThrowException()
    {
        Action action = () => new Product(1, "Pão de Forma", "aa", 14.99m);
        action.Should().Throw<DomainValidationException>().WithMessage("Invalid description. Description must have at least 10 characters");
    }
    
    [Fact]
    public void CreateProduct_WithNegativePrice_ShouldThrowException()
    {
        Action action = () => new Product(1, "Pão de Forma", "Pão de forma gostoso", -5.0m);
        action.Should().Throw<DomainValidationException>().WithMessage("Invalid Price. Price cannot be negative");
    }
}