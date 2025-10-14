using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebasket
{
    public class Order
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public List<Product> Products { get; set; } = new List<Product>();
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; } = 0;
        public Delivery Delivery { get; set; }


        public Order(List<Product> products, Customer customer)
        {
            Products = products;
            Customer = customer;
            TotalPrice = CalculateTotalPrice(products);
        }

        public decimal CalculateTotalPrice(List<Product> products)
        {
            decimal totalPrice = 0;
            for (int i = 0; i < products.Count; i++)
            {
                totalPrice += products[i].Price;
            }
            return totalPrice;
        }

        public void ProcessDelivery()
        {
            Delivery.HandleDelivery();
        }
        //// Methods for adding, removing, updating orders
        //public static void AddOrder(Order order)
        //{
        //    orders.Add(order);
        //}

        //public static void RemoveOrder(Order order)
        //{
        //    for (int i = 0; i < orders.Count; i++)
        //    {
        //        Console.WriteLine($"{i}: {orders[i].OrderId}");
        //    }

        //    Console.Write("Vilken order vill du ta bort? ");

        //    int index;
        //    string userInput = Console.ReadLine();
        //    bool isNumber = int.TryParse(userInput, out index);

        //    if (isNumber && index < orders.Count && index >= 0)
        //    {
        //        orders.RemoveAt(index);
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Du behöver ange en siffra mellan 0 och {orders.Count - 1}.");
        //    }
        //}

    }
}
