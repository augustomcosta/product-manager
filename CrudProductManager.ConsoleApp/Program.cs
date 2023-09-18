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

                if (responseCreate.IsSuccessStatusCode)
                {
                    string responseContent = await responseCreate.Content.ReadAsStringAsync();
                    
                    int newProductId;
                    
                    if (int.TryParse(responseContent, out newProductId))
                    {
                        Console.WriteLine($"Product added sucessfully. ID: {newProductId}");
                    }
                }
                else
                {
                    Console.WriteLine($"Error adding product. Status {responseCreate.StatusCode} ");
                }

                break;
        }
    }
}
