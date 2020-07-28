using System;
using System.Collections.Generic;
using domain = PizzaStore.Domain.Models;
using storing = PizzaStore.Storing;
using PizzaStore.Storing.Repositories;

namespace PizzaStore.Client
{
     public class Driver
     {
          static void Main()
          {
               Welcome();
               // var pizza = new Pizza()
               // {
               //      Name = "Cheese Pizza",
               //      Crust = new Crust() { Name = "NY Style"},
               //      Size = new Size() {Name = "M"},
               //      Toppings = new List<Topping>() {new Topping() {Name = "Cheese"}}
               // };

               //pr.Create(pizza);
               //Console.ReadLine();
          }

          static void Welcome()
          {
               System.Console.WriteLine("Welcome to the Pizza Shop");
               System.Console.WriteLine("Best Pizza in the 462");
               //select either user or store story          
               try
               {
                    //ask to create or login
                    var pr = new PizzaRepo(); 
                    domain.Store store = StoreSelect();
                    domain.User user = new domain.User(){Orders = store.Orders};
                    domain.Order order = store.CreateOrder();
                    pr.CreateOrder(order);
                    Menu(order, user, store, pr); //set orders equiv for this run of program
               }
               catch (Exception ex)
               {
                    System.Console.WriteLine(ex.Message);
               }
          }

          static void Menu(domain.Order cart, domain.User u, domain.Store s, PizzaRepo pr)
          {
                             
               var order = true;
               do
               {
                    s.PrintMenu();

                    int select;

                    int.TryParse(Console.ReadLine(), out select);

                    switch (select)
                    {
                         case 1:
                              pr.CreatePizza(cart.CreatePizza("Cheesy Pizza","L", "NY Style", new List<string> { "Cheese, Sauce" }));
                              System.Console.WriteLine("Added Cheese Pizza");
                              break;
                         case 2:
                              pr.CreatePizza(cart.CreatePizza("Pepperoni Pizza","L", "NY Style", new List<string> { "Cheese, Sauce, Pepperoni" }));
                              System.Console.WriteLine("Added Pepperoni Pizza");
                              break;
                         case 3:
                              pr.CreatePizza(cart.CreatePizza("Hawaiian Pizza","L", "NY Style", new List<string> { "Cheese, Sauce, Pineapple, Ham" }));
                              System.Console.WriteLine("Added Hawaiian Pizza");
                              break;
                         case 4:
                              pr.CreatePizza(cart.CreatePizza("Meat Lovers Pizza","L", "NY Style", new List<string> { "Cheese, Sauce, Pepperoni, Sausage, Bacon" }));                    
                              System.Console.WriteLine("Added Meat Lovers Pizza");
                              break;
                         case 5:
                              domain.Pizza custom = cart.CustomPizza();
                              pr.CreatePizza(custom);
                              System.Console.WriteLine("Added Custom Pizza");
                              break;
                         case 6:
                              //var fmw = new FileManager();
                              //fmw.Write(cart);
                              break;
                         case 7:
                              //var fmr = new FileManager();
                              //DisplayCart(fmr.Read());
                              break;
                         case 8:
                              System.Console.WriteLine("Exit Order");
                              order = false;
                              break;
                    }
               } while (order);
          }
          static void StoreManager()
          {
               //for store story
          }
          static void DisplayCart(domain.Order cart, PizzaRepo pr)
          {
               int cnt = 1;
               foreach (var pizza in cart.Pizzas)
               {
                    //System.Console.WriteLine("Pizza " + cnt + ": " + pizza.ToString());
                    cnt += 1;
               }

               // foreach (var item in pr.ReadAll())
               // {
               //      Console.WriteLine(item);
               // }
          }
          static void UserSearch(domain.User user)
          {

               System.Console.WriteLine("Enter Name");
               string name = Console.ReadLine();
               System.Console.WriteLine("Enter Username");
               string uname = Console.ReadLine();
               //get uname from db and match
               System.Console.WriteLine("Enter Password");
               string pword = Console.ReadLine();

               user.Name = name;
               user.Username = uname;
               user.Password = pword;
               
          }
          static domain.Store StoreSelect()
          {
               int choice;
               do
               {
                    Console.WriteLine("Select 1 for West Side Store");
                    Console.WriteLine("Select 2 for East Side Store");
                    int.TryParse(Console.ReadLine(), out choice);

                    if (choice == 1)
                    {
                         return new domain.Store(){Name = "West End Pizzeria"}; //West
                         
                    }
                    else if (choice == 2)
                    {
                         return new domain.Store(){Name = "East Side Pizza Shop"}; //East      

                    }
                    else
                    {
                         System.Console.WriteLine("Enter either 1 or 2");
                    }

               } while (choice < 1 && choice > 2);

               return null; //should pop error
          }
     }
}
