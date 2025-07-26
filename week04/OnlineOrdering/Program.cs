using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        List<Order> orders = new List<Order>();

        Address address1 = new Address("Av street 1", "Ferreñafe", "Lambayeque", "Perú");
        Customer customer1 = new Customer("customer 1", address1);
        Product product1 = new Product("Product 1", 1, 4.5, 10);
        Product product2 = new Product("Product 2", 2, 14.6, 20);
        Product product3 = new Product("Product 3", 3, 30, 2);
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);
        orders.Add(order1);

        Address address2 = new Address("Av street 2", "City 2", "Utah", "USA");
        Customer customer2 = new Customer("customer 2", address2);
        Product product4 = new Product("Product 4", 4, 13.6, 15);
        Product product5 = new Product("Product 5", 5, 451, 4);
        Product product6 = new Product("Product 6", 6, 2, 300);
        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);
        orders.Add(order2);

        foreach (Order order in orders)
        {
            string packingLabel = order.GetPackingLabel();
            string shippingLabel = order.GetShippingLabel();
            double totalPrice = order.GetTotalPrice();
            Console.WriteLine("New Order");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(packingLabel);
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(shippingLabel);
            Console.WriteLine($"Total price: {totalPrice}");
            Console.WriteLine();
        }

    }
}