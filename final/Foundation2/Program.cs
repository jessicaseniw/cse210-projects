// 2. **Foundation Program #2 (Encapsulation):**
//    - Defined classes `Product`, `Address`, `Customer`, and `Order` to model products, addresses, customers, and orders.
//    - Used encapsulation by defining properties with getters/setters and methods to calculate total order costs, generate packing labels, and shipping labels based on customer addresses and products.

// In the `Main` program, I instantiated these classes to simulate customer orders with different products and addresses. For each order, I calculated and displayed details such as packing labels, shipping labels, and total costs.

// These steps represent the progress so far in implementing the Foundation 4 project. The code is structured using principles of abstraction and encapsulation to model and manipulate entities related to YouTube videos and online product orders.

using System;
using System.Collections.Generic;

// Class to represent a product
public class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal TotalCost
    {
        get { return Price * Quantity; }
    }
}

// Class to represent a customer's address
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string Country { get; set; }

    public bool IsInUSA()
    {
        return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {StateProvince}, {Country}";
    }
}

// Class to represent a customer
public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

// Class to represent an order
public class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    public Order()
    {
        Products = new List<Product>();
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in Products)
        {
            totalCost += product.TotalCost;
        }

        // Adding shipping cost based on customer location
        decimal shippingCost = Customer.IsInUSA() ? 5 : 35;
        totalCost += shippingCost;

        return totalCost;
    }

    public string GeneratePackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    public string GenerateShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"Customer Name: {Customer.Name}\n";
        label += $"Customer Address: {Customer.Address}\n";
        return label;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address { Street = "123 Main St", City = "Anytown", StateProvince = "CA", Country = "USA" };
        Address address2 = new Address { Street = "456 Oak Ave", City = "Othercity", StateProvince = "TX", Country = "Mexico" };

        // Create customers
        Customer customer1 = new Customer { Name = "John Doe", Address = address1 };
        Customer customer2 = new Customer { Name = "Jane Smith", Address = address2 };

        // Create products
        Product product1 = new Product { Name = "Laptop", ProductId = 101, Price = 1200, Quantity = 2 };
        Product product2 = new Product { Name = "Mouse", ProductId = 102, Price = 25, Quantity = 3 };
        Product product3 = new Product { Name = "Keyboard", ProductId = 103, Price = 80, Quantity = 1 };

        // Create orders
        Order order1 = new Order { Customer = customer1 };
        order1.Products.Add(product1);
        order1.Products.Add(product2);

        Order order2 = new Order { Customer = customer2 };
        order2.Products.Add(product3);

        // Display order details
        Console.WriteLine("Order 1 Details:");
        Console.WriteLine(order1.GeneratePackingLabel());
        Console.WriteLine(order1.GenerateShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");

        Console.WriteLine("\nOrder 2 Details:");
        Console.WriteLine(order2.GeneratePackingLabel());
        Console.WriteLine(order2.GenerateShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}
