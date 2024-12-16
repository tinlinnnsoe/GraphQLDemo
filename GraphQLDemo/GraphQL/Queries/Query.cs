using GraphQLDemo.Data.Models;

namespace GraphQLDemo.GraphQL.Queries
{
    public class Query
    {
        // Retrieve products from in-memory store
        public IEnumerable<Product> GetProducts() => InMemoryData.Products;

        // Retrieve customers from in-memory store
        public IEnumerable<Customer> GetCustomers(int? id = null, string? name = null, int? top = null)
        {
            var customers = InMemoryData.Customers.AsEnumerable();

            // Filter by ID if provided
            if (id.HasValue)
            {
                customers = customers.Where(c => c.Id == id.Value);
            }

            // Filter by Name if provided (case-insensitive)
            if (!string.IsNullOrWhiteSpace(name))
            {
                customers = customers.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            // Sort by Name (ascending) and limit results if top is provided
            if (top.HasValue)
            {
                customers = customers.OrderBy(c => c.Name).Take(top.Value);
            }

            return customers;
        }
    }

    // Static class for in-memory storage
    public static class InMemoryData
    {
        // Initialize products
        public static List<Product> Products { get; } = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000 },
            new Product { Id = 2, Name = "Mouse", Price = 25 }
        };

        // Initialize customers
        public static List<Customer> Customers { get; } = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Name = "John",
                Address = "Address 1",
                City  = "Califonia",
                Products = new List<Product>
                {
                    Products[0], // Laptop
                    Products[1]  // Mouse
                }
            },
            new Customer
            {
                Id = 2,
                Name = "Patrick",
                Address = "Address 2",
                City = "London",
                Products = new List<Product>
                {
                    Products[0]  // Laptop
                }
            }
        };
    }
}
