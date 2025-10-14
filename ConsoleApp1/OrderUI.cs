using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebasket
{
    public static class OrderUI
    {
        // List of orders
        static List<Order> orders = new List<Order>();

        // Create list of products here:
        static List<Product> availableProductList = new List<Product>
        {
            new Product("Laptop", 1, 5999.9m),
            new Product("Phone", 2, 599.9m),
            new Product("Mouse", 4, 299.9m),
        };

        static List<Product> shoppingCart = new List<Product>();

        public static void Menu()
        {
            Console.WriteLine("Welcome to our shop");
            // Shop display + add items to cart:
            while (true)
            {
                string[] displayOptions = { "Add new product", "Remove Product", "Checkout", "Exit" };
                
                for (int i = 0; i < displayOptions.Length; i++)
                {
                    Console.WriteLine($"[{i}]: {displayOptions[i]}");
                }
                Console.Write("Enter your choice: ");
                string userInput = Console.ReadLine();
                bool success = int.TryParse(userInput, out int userIndex);
                switch (userIndex)
                {
                    case 0:
                        // add product to shopping cart
                        AddProduct();
                        break;
                    case 1:
                        // Remove product from shopping cart
                        RemoveItem(shoppingCart);
                        break;
                    case 2:
                        // Checkout, gets customer from user and add new order to orders
                        Customer customer = CreateCustomer();
                        Order order = new Order(shoppingCart, customer);
                        AddOrder<Order>(orders, order);
                        PrintOrder(order);
                        shoppingCart.Clear();
                        break;
                    case 3:
                        return;
                }
            }
        }

        // Methods for adding, removing, updating orders
        public static void AddOrder<T>(List<T> list, T item)
        {
            list.Add(item);
        }

        public static Customer CreateCustomer()
        {
            // Input of customer data
            Console.WriteLine("Please enter your full name:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Please enter your full address:");
            string address = Console.ReadLine();

            Console.WriteLine("Please enter your email:");
            string email = Console.ReadLine();

            return new Customer(fullName, address, email);
        }

        public static void RemoveItem<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string displayItem = "";
                if (list[i] is Order order)
                {

                    displayItem = order.OrderId.ToString();
                }
                else if (list[i] is Product product)
                {
                    displayItem = product.Name;
                }
                Console.WriteLine($"{i}: {displayItem}");
            }

            Console.WriteLine("What order would you like to remove?");

            string userInput = Console.ReadLine();
            bool isNumber = int.TryParse(userInput, out int index);

            if (isNumber && index < list.Count && index >= 0)
            {
                list.RemoveAt(index);
            }
            else
            {
                Console.WriteLine($"You need to input a number between 0 till {list.Count - 1}.");
            }
        }

        public static void AddProduct()
        {
            Console.WriteLine("Available list products:");
            for (int i = 0; i < availableProductList.Count; i++)
            {
                Console.WriteLine($"[{i}]: {availableProductList[i].Name} - ({availableProductList[i].Quantity}) cost {availableProductList[i].Price} SEK");
            }
            Console.WriteLine("Which item would you like to purchase? Write 'checkout' if you want to exit.");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int correctInput) && correctInput >= 0 && correctInput < availableProductList.Count && availableProductList[correctInput].Quantity >= 0)
            {
                shoppingCart.Add(availableProductList[correctInput]);
                availableProductList[correctInput].Quantity--;
            }
        }

        public static void PrintOrder(Order order)
        {
            // orderid, productlist, customer object, datetime, totalprice, 
            Console.WriteLine($"Your Order\nDate: {order.OrderDate}\nItems in cart: {order.Products.Count}\n");
            foreach (Product product in order.Products)
            {
                Console.WriteLine($"{product.Name} - {product.Price} SEK");
            }
            Console.WriteLine($"\nTotal Price: {order.TotalPrice}");
        }

        public static void ChooseDelivery(Order order)
        {

            string[] displayOptions = { "Standard Delivery", "Express Delivery" };

            for (int i = 0; i < displayOptions.Length; i++)
            {
                Console.WriteLine($"[{i}]: {displayOptions[i]}");
            }
            Console.Write("Enter your choice: ");
            string userInput = Console.ReadLine();
            bool success = int.TryParse(userInput, out int userIndex);
            switch (userIndex)
            {
                case 0:
                    order.Delivery = new StandardDelivery();
                    order.ProcessDelivery();
                    break;

                case 1:
                    order.Delivery = new ExpressDelivery();
                    order.ProcessDelivery();
                    break;
            }
        }
    }
}
