using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models;
using PizzaStore.Storing.Repositories;

namespace PizzaStore.Client
{
     class Program
     {
          static void Main()
          {
               Welcome();
               var pr = new PizzaRepository();
               // var pizza = new Pizza()
               // {
               //      Name = "Cheese Pizza",
               //      Crust = new Crust() { Name = "NY Style"},
               //      Size = new Size() {Name = "M"},
               //      Toppings = new List<Topping>() {new Topping() {Name = "Cheese"}}
               // };

               //pr.Create(pizza);
               Console.ReadLine();

               // foreach (var item in pr.ReadAll())
               // {
               //      Console.WriteLine(item);
               // }
          }

          static void Welcome()
          {


               System.Console.WriteLine("Welcome to the Pizza Shop");
               System.Console.WriteLine("Best Pizza in the 462");
               int choice;
               do
               {
                    System.Console.WriteLine("Select 1 for User");
                    System.Console.WriteLine("Select 2 for Store");
                    int.TryParse(Console.ReadLine(), out choice);
                    List<Pizza> cart5 = new List<Pizza>();
                    var user = new User();
                    switch (choice)
                    {
                         case 1:
                              
                              UserSearch(user);
                              var store = StoreSelect();
                              try
                              {
                                   //ask to create or login
                                   Menu(store.CreateOrder(), user, store);
                              }
                              catch (Exception ex)
                              {
                                   System.Console.WriteLine(ex.Message);
                              }
                              break;
                         case 2:
                              //go to store directory
                              break;
                    }
               } while (choice < 1 && choice > 2);
          }

          static void Menu(Order cart, User u, Store s)
          {
               var order = true;
               do
               {
                    //s.PrintMenu();

                    int select;

                    int.TryParse(Console.ReadLine(), out select);

                    // switch (select)
                    // {
                    //      case 1:
                    //           cart.CreatePizza("L", "Regular", new List<string> { "Cheese" });
                    //           System.Console.WriteLine("Added Cheese Pizza");
                    //           break;
                    //      case 2:
                    //           cart.CreatePizza("L", "Regular", new List<string> { "Cheese, Pepperoni" });
                    //           System.Console.WriteLine("Added Pepperoni Pizza");
                    //           break;
                    //      case 3:
                    //           cart.CreatePizza("L", "Regular", new List<string> { "Cheese, Pineapple, Ham" });
                    //           System.Console.WriteLine("Added Hawaiian Pizza");
                    //           break;
                    //      case 4:
                    //           cart.CreatePizza("L", "Regular", new List<string> { "Cheese, Pepperoni, Sausage, Meatball, Bacon" });
                    //           System.Console.WriteLine("Added Meat Lovers Pizza");
                    //           break;
                    //      case 5:
                    //           cart.CreatePizza("L", "Regular", new List<string> { "Cheese, Buffalo, Chicken, Ranch" });
                    //           System.Console.WriteLine("Added Custom Pizza");
                    //           break;
                    //      case 6:
                    //           var fmw = new FileManager();
                    //           fmw.Write(cart);
                    //           break;
                    //      case 7:
                    //           var fmr = new FileManager();
                    //           DisplayCart(fmr.Read());
                    //           break;
                    //      case 8:
                    //           System.Console.WriteLine("Exit Order");
                    //           order = false;
                    //           break;
                    // }

               } while (order);
          }
          static void StoreManager()
          {
               //for store story
          }

          static void DisplayCart(Order cart)
          {
               int cnt = 1;
               foreach (var pizza in cart.Pizzas)
               {
                    System.Console.WriteLine("Pizza " + cnt + ": " + pizza.ToString());
                    cnt += 1;
               }
          }

          static User UserSearch(User user)
          {
               int choice;
               do
               {
                    Console.WriteLine("Select 1 to Login (Current User)");
                    Console.WriteLine("Select 2 to Register (New User)");
                    int.TryParse(Console.ReadLine(), out choice);

                    switch (choice)
                    {
                         case 1:
                              System.Console.WriteLine("Enter Name");
                              string name = Console.ReadLine();

                              System.Console.WriteLine("Enter Username");
                              string uname = Console.ReadLine();
                              //get uname from db and match
                              System.Console.WriteLine("Enter Password");
                              string pword = Console.ReadLine();
                              break;
                         case 2:
                              System.Console.WriteLine("Enter Name");
                              string newName = Console.ReadLine();
                              
                              System.Console.WriteLine("Enter Username");
                              string newUser = Console.ReadLine();

                              System.Console.WriteLine("Enter Password");
                              string newPassword = Console.ReadLine();

                              //send to User()
                              break;
                         default:
                              System.Console.WriteLine("Enter either 1 or 2");
                              break;

                    }

               }while(choice < 1 && choice > 2);
               return new User();
          }

          static Store StoreSelect()
          {
               int choice;
               do
               {
                    Console.WriteLine("Select 1 for West Side Store");
                    Console.WriteLine("Select 2 for East Side Store");
                    int.TryParse(Console.ReadLine(), out choice);

                    if(choice == 1)
                    {
                         var store1 = new Store(); //West
                         return store1; 
                    }
                    else if (choice == 2)
                    {
                         var store2 = new Store(); //East
                         return store2;
                    }
                    else
                    {
                         System.Console.WriteLine("Enter either 1 or 2");
                    }

               }while(choice < 1 && choice > 2);

               return null;
          }
     }
}
