using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
     public class Order
     {
          public List<Pizza> Pizzas { get; set; }
          public DateTime DateOrdered { get; set; }

          public Pizza CreatePizza(string name, string size, string crust, List<string> toppings)
          {
               Pizza p = new Pizza(toppings)
               {
                    Name = new Name(){PizzaName = name},
                    Size = new Size(){Name = size},
                    Crust = new Crust(){Name = crust}
               };
               Pizzas.Add(p); //toppings set in constructor
               
               return p;
          }
          public Pizza CustomPizza()
          {
               var chooseSize = false;
               var chooseCrust = false;
               var chooseTops = -1;
               string size = " ";
               string crust = " "; 
               List<string> toppings = new List<string>();
               do
               {
                    System.Console.WriteLine("Select 1 for Small Pizza");
                    System.Console.WriteLine("Select 2 for Medium Pizza");
                    System.Console.WriteLine("Select 3 for Large Pizza");
                    System.Console.WriteLine("Select 4 for Party Pizza");

                    int selectSize;
                    int.TryParse(Console.ReadLine(), out selectSize);

                    switch (selectSize)
                     {
                         case 1:
                              size = "S";
                              chooseSize = true;
                              break;
                         case 2:
                              size = "M";
                              chooseSize = true;
                              break;
                         case 3:
                              size = "L";
                              chooseSize = true;
                              break;
                         case 4:
                              size = "PARTY";
                              chooseSize = true;
                              break;
                     }
               }while(!chooseSize);

               do
               {
                    System.Console.WriteLine("Select 1 for New York Style");
                    System.Console.WriteLine("Select 2 for Sicilian Square");
                    System.Console.WriteLine("Select 3 for Chicago Deep Dish");

                    int selectCrust;
                    int.TryParse(Console.ReadLine(), out selectCrust);

                    switch (selectCrust)
                     {
                         case 1:
                              crust = "NY";
                              chooseCrust = true;
                              break;
                         case 2:
                              crust = "SQ";
                              chooseCrust = true;
                              break;
                         case 3:
                              crust = "CHI";
                              chooseCrust = true;
                              break;
                     }
               }while(!chooseCrust);

               do
               {
                    System.Console.WriteLine("Select 1 to add Cheese");
                    System.Console.WriteLine("Select 2 to add Sauce");
                    System.Console.WriteLine("Select 3 to add Pepperoni");
                    System.Console.WriteLine("Select 4 to add Ham");
                    System.Console.WriteLine("Select 5 to add Bacon");
                    System.Console.WriteLine("Select 6 to add Chicken");
                    System.Console.WriteLine("Select 7 to add Sausage");
                    System.Console.WriteLine("Select 8 to add Meatball");
                    System.Console.WriteLine("Select 9 to finish toppings");

                    int selectTops;
                    int.TryParse(Console.ReadLine(), out selectTops);

                    switch (selectTops)
                     {
                         case 1:
                              toppings.Add("Cheese"); //Potential to add inner switches for more cheese types
                              break;
                         case 2:
                              toppings.Add("Sauce"); //Potential to add inner switches for more sauce types
                              break;
                         case 3:
                              toppings.Add("Pepperoni"); 
                              break;
                         case 4:
                              toppings.Add("Ham"); 
                              break;
                         case 5:
                              toppings.Add("Bacon"); 
                              break;
                         case 6:
                              toppings.Add("Chicken"); 
                              break;
                         case 7:
                              toppings.Add("Sausage"); 
                              break;
                         case 8:
                              toppings.Add("Meatball"); 
                              break;
                         case 9:
                              chooseTops = 0;
                              break;
                     }
               }while(chooseTops != 0); //and topping less than 2 or more than 5
               return new Pizza(toppings)
               {
                    Name = new Name{PizzaName = "Customized Pizza"},
                    Size = new Size{Name = size},
                    Crust = new Crust{Name = crust},
               };
          }

          public Order()
          {
               Pizzas = new List<Pizza>();
          }
     }
}