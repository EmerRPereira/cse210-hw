/*
Course: CSE 210: Programming with Classes
W04 Assignment: Online Ordering Program
Author: Emerson Ronald Pereira
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        // ===== ORDER 1 (USA Customer) =====
        Address addr1 = new Address("123 Main St", "Chicago", "IL", "USA");
        Customer cust1 = new Customer("John Doe", addr1);
        Order order1 = new Order(cust1);

        order1.AddProduct(new Product("Notebook", "A100", 3.50, 5));
        order1.AddProduct(new Product("Pencil", "B200", 1.00, 10));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        // ===== ORDER 2 (International Customer) =====
        Address addr2 = new Address("Rua Francisco Fruet, 726", "Curitiba", "PR", "Brazil");
        Customer cust2 = new Customer("Emerson Ronald", addr2);
        Order order2 = new Order(cust2);

        order2.AddProduct(new Product("Backpack", "C300", 40.00, 1));
        order2.AddProduct(new Product("Water Bottle", "D400", 10.00, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}\n");
    }
}
