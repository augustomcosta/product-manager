using Product_Manager.Domain.Models.Base;
using Product_Manager.Domain.Validation;

namespace Product_Manager.Domain.Models;

public sealed class Product : ModelBase<Product>
{
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }

    public Product(int id,string name, string description, decimal price) : base(id)
    {
        Validate(name,description,price);
    }
    private void Validate(string name, string description, decimal price)
    {
        ValidateName(name);
        ValidateDescription(description);
        ValidatePrice(price);
    }

    private void ValidateName(string name)
    {
        DomainValidationException.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainValidationException.When(name.Length < 2, "Invalid name. Name must have at least 2 characters");
        DomainValidationException.When(name.Length > 50, "Invalid name. Name must have a maximum of 50 characters");
        Name = name;
    }   

    private void ValidateDescription(string description)
    {
        DomainValidationException.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");
        DomainValidationException.When(description.Length < 10, "Invalid description. Description must have at least 2 characters");
        DomainValidationException.When(description.Length > 200, "Invalid description. Description must have a maximum of 50 characters");
        Description = description;
    }

    private void ValidatePrice(decimal price)
    {
        DomainValidationException.When(price > 0, "Invalid Price. Price cannot be negative");
        Price = price;
    }

    public override void UpdateFrom(Product newProduct)
    {
        if (newProduct == null)
        {
            throw new ArgumentException("Invalid product.");
        }
        Validate(newProduct.Name!, newProduct.Description!, newProduct.Price);
    }
}