using GraphQLDemo.Data.Models;
using GraphQLDemo.GraphQL.Queries;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.GraphQL.Mutations
{
    public class Mutation
    {
        private readonly ITopicEventSender _eventSender;

        public Mutation(ITopicEventSender eventSender)
        {
            _eventSender = eventSender;
        }

        // Add a new product to the in-memory data
        public async Task<Product> AddProduct(int id, string name, decimal price)
        {
            var product = new Product { Id = id, Name = name, Price = price };
            InMemoryData.Products.Add(product);

            // Send event to notify about the new product
            await _eventSender.SendAsync("ProductAdded", product);

            return product;
        }

        // Update an existing product by ID
        public Product UpdateProduct(int id, string name, decimal price)
        {
            var product = InMemoryData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) throw new Exception($"Product with ID {id} not found.");

            product.Name = name;
            product.Price = price;
            return product;
        }

        // Delete a product by ID
        public bool DeleteProduct(int id)
        {
            var product = InMemoryData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) throw new Exception($"Product with ID {id} not found.");

            InMemoryData.Products.Remove(product);
            return true;
        }

        // Add a new customer to the in-memory data
        public Customer AddCustomer(int id, string name, string address, List<int> productIds)
        {
            var products = InMemoryData.Products.Where(p => productIds.Contains(p.Id)).ToList();
            var customer = new Customer { Id = id, Name = name, Address = address, Products = products };
            InMemoryData.Customers.Add(customer);
            return customer;
        }

        // Update an existing customer by ID
        public Customer UpdateCustomer(int id, string name, string address, List<int> productIds)
        {
            var customer = InMemoryData.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) throw new Exception($"Customer with ID {id} not found.");

            var products = InMemoryData.Products.Where(p => productIds.Contains(p.Id)).ToList();
            customer.Name = name;
            customer.Address = address;
            customer.Products = products;
            return customer;
        }

        // Delete a customer by ID
        public bool DeleteCustomer(int id)
        {
            var customer = InMemoryData.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) throw new Exception($"Customer with ID {id} not found.");

            InMemoryData.Customers.Remove(customer);
            return true;
        }
    }
}
