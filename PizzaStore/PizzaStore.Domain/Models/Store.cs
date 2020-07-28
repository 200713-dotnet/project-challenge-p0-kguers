using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
     public class Store
     {
          public List<Order> Orders { get; set; }
          public string Name { get; set; }

          public Order CreateOrder()
          {
               return new Order(){DateOrdered = DateTime.Now};
          }

          public void PrintMenu()
          {
               System.Console.WriteLine("Select Menu (Default Large New York Style)");
               System.Console.WriteLine("Select 1 for Cheese Pizza");
               System.Console.WriteLine("Select 2 for Pepperoni Pizza");
               System.Console.WriteLine("Select 3 for Hawaiian Pizza");
               System.Console.WriteLine("Select 4 for Meat Lovers");
               System.Console.WriteLine("Select 5 to Customize Pizza");
               System.Console.WriteLine("Select 6 to Save Cart");
               System.Console.WriteLine("Select 7 to Display Cart");
               System.Console.WriteLine("Select 8 to Finish Order");
          }
     }
     
}