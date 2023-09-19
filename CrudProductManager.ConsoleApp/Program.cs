using CrudProductManager.API.Domain.Models;
using CrudProductManager.ConsoleApp.Services;

Console.WriteLine("## Product Manager ##\n");

ApiService apiService = new();

while (true)
{
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. Remove Product by Id");
    Console.WriteLine("3. Edit product by Id");
    Console.WriteLine("4. Get all products");
    Console.WriteLine("5. Exit");

    string? userInputString = (Console.ReadLine());

    if (int.TryParse(userInputString, out int userInput))
    {
        switch (userInput)
        {
            case 1:
                
                Console.WriteLine("\nType the name of the product:");
                string? productName = Console.ReadLine();
                Console.WriteLine("\nType the description of the product:");
                string? productDescription = Console.ReadLine();
                Console.WriteLine("\nType the price of the product:");
                decimal productPrice = Convert.ToDecimal(Console.ReadLine());

                Product newProduct = new Product(0, productName!, productDescription!, productPrice);

                HttpResponseMessage responseCreate = await apiService.Create(newProduct);

                break;
            
            case 2:
                
                Console.WriteLine("Type the ID of the product you wish to delete:");
                int productId = Convert.ToInt32(Console.ReadLine());
                
                HttpResponseMessage responseDelete = await apiService.Delete(productId);
                
                break;
            case 3:
                
                Console.WriteLine("Type the ID of the product you wish to edit: ");
                int productToEditId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Type the new Name:");
                string? newName = Console.ReadLine();
                Console.WriteLine("Type the new Description:");
                string? newDesc = Console.ReadLine();
                Console.WriteLine("Type the new Price:");
                decimal newPrice = Convert.ToDecimal(Console.ReadLine());

                Product updatedProduct = new(productToEditId, newName!, newDesc!,newPrice);

                HttpResponseMessage responseUpdate = await apiService.Update(productToEditId, updatedProduct);
                
                break;
            case 4:
                await apiService.GetAll();
                break;
            
            case 5:
                
                Console.WriteLine("Shutting down Product Manager.");
                Environment.Exit(0);
                
                break;
            
            default:
                
                Console.WriteLine("\nPlease, choose a valid option. (1 - 5)\n");
                
                break;
        }
    }
}
