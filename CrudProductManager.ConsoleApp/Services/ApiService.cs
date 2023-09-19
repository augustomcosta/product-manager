using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CrudProductManager.API.Domain.Models;

namespace CrudProductManager.ConsoleApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient = new();

        public ApiService()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:5268/");
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Product");

                if (response.IsSuccessStatusCode)
                {
                    var produtos = await response.Content.ReadFromJsonAsync<List<Product>>();
                    Console.WriteLine("Products:");
                    foreach (var produto in produtos)
                    {
                        Console.WriteLine($"ID: {produto.Id}, Name: {produto.Name}, Description: {produto.Description}, Price: {produto.Price}");
                    }

                    return produtos;
                }
                else
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failed to get products. Status Code: {response.StatusCode}, Content: {content}");
                    return null;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"General Exception: {e}");
                throw;
            }
        }


        public async Task<HttpResponseMessage> GetById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Product/{id}");
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Successfully found the product: {response}");
                }
                else
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failed to get product. Status Code: {response.StatusCode}, Content: {content}");
                }

                return response;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"General Exception: {e}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> Create(Product newProduct)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Product", newProduct);
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Successfully created the product: {await response.Content.ReadAsStringAsync()}");
                }
                else
                {
                    Console.WriteLine($"Failed to create the product. Status Code: {response.StatusCode}, Content: {response.Content.ReadAsStringAsync().Id}");
                }

                return response;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"General Exception: {e}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> Update(int id, Product updatedProduct)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Product/{id}", updatedProduct);
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Successfully updated the product: {await response.Content.ReadAsStringAsync()}");
                }
                else
                {
                    Console.WriteLine($"Failed to update the product. Status Code: {response.StatusCode}, Content: {response.Content.ReadAsStringAsync()}");
                }

                return response;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"General Exception: {e}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Product/{id}");
                string content = await response.Content.ReadAsStringAsync();
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Successfully deleted the product: {content}");
                }
                else
                {
                    Console.WriteLine($"Failed to delete the product. Status Code: {response.StatusCode}, Content: {content}");
                }

                return response;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"General Exception: {e}");
                throw;
            }
        }
    }
}
