using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime DateAdded { get; set; }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Apple", Category = "Fruits", Price = 0.99m, Quantity = 50, DateAdded = DateTime.Parse("2023-05-20") },
            new Product { Id = 2, Name = "Banana", Category = "Fruits", Price = 0.79m, Quantity = 30, DateAdded = DateTime.Parse("2023-05-21") },
            new Product { Id = 3, Name = "Orange", Category = "Fruits", Price = 0.69m, Quantity = 40, DateAdded = DateTime.Parse("2023-05-22") },
            new Product { Id = 4, Name = "Grapes", Category = "Fruits", Price = 1.99m, Quantity = 20, DateAdded = DateTime.Parse("2023-05-23") },
            new Product { Id = 5, Name = "Mango", Category = "Fruits", Price = 1.49m, Quantity = 25, DateAdded = DateTime.Parse("2023-05-24") },
            new Product { Id = 6, Name = "Laptop", Category = "Electronics", Price = 999.99m, Quantity = 10, DateAdded = DateTime.Parse("2023-05-20") },
            new Product { Id = 7, Name = "Mobile Phone", Category = "Electronics", Price = 799.99m, Quantity = 15, DateAdded = DateTime.Parse("2023-05-21") },
            new Product { Id = 8, Name = "Television", Category = "Electronics", Price = 1499.99m, Quantity = 5, DateAdded = DateTime.Parse("2023-05-22") },
            new Product { Id = 9, Name = "Shirt", Category = "Clothing", Price = 19.99m, Quantity = 50, DateAdded = DateTime.Parse("2023-05-23") },
            new Product { Id = 10, Name = "Jeans", Category = "Clothing", Price = 39.99m, Quantity = 30, DateAdded = DateTime.Parse("2023-05-24") }
        };

        // Query 1: Get all products
        var allProducts = products;
        Console.WriteLine("All Products:");
        foreach (var product in allProducts)
        {
            Console.WriteLine($"{product.Id} - {product.Name} - {product.Category} - ${product.Price} - Quantity: {product.Quantity} - Added: {product.DateAdded.ToShortDateString()}");
        }

        Console.WriteLine();


        // Query 2: Get the product with the highest price
        var highestPricedProduct = products.OrderByDescending(p => p.Price).FirstOrDefault();
        Console.WriteLine($"Highest Priced Product: {highestPricedProduct?.Name}");

        Console.WriteLine();


        // Query 3: Get products with a quantity greater than 20
        var highQuantityProducts = products.Where(p => p.Quantity > 20);
        Console.WriteLine("Products with Quantity > 20:");
        foreach (var product in highQuantityProducts)
        {
            Console.WriteLine($"{product.Name}");
        }

        Console.WriteLine();


        // Query 4: Get the number of products added in May 2023
        int productsAddedInMayCount = products.Count(p => p.DateAdded.Year == 2023 && p.DateAdded.Month == 5);
        Console.WriteLine($"Products Added in May 2023: {productsAddedInMayCount}");

        Console.WriteLine();


        // Query 5: Get the average price of products in the "Electronics" category
        var electronicsAveragePrice = products.Where(p => p.Category == "Electronics").Average(p => p.Price);
        Console.WriteLine($"Average Price of Electronics: {electronicsAveragePrice}");

        Console.WriteLine();


        // Query 6: Get the three products with the lowest quantity
        var lowestQuantityProducts = products.OrderBy(p => p.Quantity).Take(3);
        Console.WriteLine("Products with Lowest Quantity:");
        foreach (var product in lowestQuantityProducts)
        {
            Console.WriteLine($"{product.Name} - Quantity: {product.Quantity}");
        }

        Console.WriteLine();


        // Query 7: Check if there are any products with a price greater than $2000
        bool hasExpensiveProducts = products.Any(p => p.Price > 2000);
        Console.WriteLine($"Has Expensive Products: {hasExpensiveProducts}");

        Console.ReadLine();


        // Query 8: Get the products with a price between $10 and $50
        var affordableProducts = products.Where(p => p.Price >= 10 && p.Price <= 50);
        Console.WriteLine("Affordable Products:");
        foreach (var product in affordableProducts)
        {
            Console.WriteLine($"{product.Name} - Price: {product.Price}");
        }

        Console.WriteLine();

        // Query 9: Get the total value of all products (price * quantity)
        decimal totalValue = products.Sum(p => p.Price * p.Quantity);
        Console.WriteLine($"Total Value of Products: {totalValue}");

        Console.WriteLine();

        // Query 10: Group products by category
        var productsByCategory = products.GroupBy(p => p.Category);
        Console.WriteLine("Products by Category:");
        foreach (var categoryGroup in productsByCategory)
        {
            Console.WriteLine($"Category: {categoryGroup.Key}");
            foreach (var product in categoryGroup)
            {
                Console.WriteLine($"{product.Name}");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

    }
} 