using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using domain = PizzaStore.Domain.Models;

namespace PizzaStore.Storing.Repositories
{
     public class PizzaRepo
     {
         
          private PizzaStoreDbContext _db = new PizzaStoreDbContext();
          
          public void CreatePizza(domain.Pizza pizza, domain.Order order, domain.Store store, domain.User user)
          {
               
               var newPizza = new Pizza();
               var newTopping = new Topping();
               var newPizzaTopping = new PizzaTopping();
               //var newOPT = new OrdersPizzaTopping();
               //var newOrder = new Orders();
               //var newStore = new Store();
               //var newUser = new Users();
               //newPizza.Crust = _db.Crust.FirstOrDefault(Crust ==> Name = pizza.Crust.Name);

               newPizza.Crust = new Crust() {Name = pizza.Crust.Name};
               newPizza.Size = new Size() {Name = pizza.Size.Name};
               newPizza.Name = pizza.Name.PizzaName;
               _db.Pizza.Add(newPizza); //git add equiv for db
               _db.SaveChanges();

               //newOrder.OrderDate = order.DateOrdered;//retrieve current order

               /*var orderNum = _db.Orders.Include(d => d.OrdersPizzaTopping)
                    .Where(f => f.OrderDate == newOrder.OrderDate)
                    .FirstOrDefault(); //should only be one order
               
               newStore.Name = store.Name;//retrieve current order
               var storeNum = _db.Store.Include(d => d.OrdersPizzaTopping)
                    .Where(f => f.Name == newStore.Name)
                    .FirstOrDefault(); //should only be one order
               
               newUser.Name = user.Name;//retrieve current order
               var userNum = _db.Users.Include(d => d.OrdersPizzaTopping)
                    .Where(f => f.Name == newUser.Name)
                    .FirstOrDefault(); //should only be one order
                */

               foreach(var item in pizza.Toppings)
               {
                    newTopping = new Topping{Name = item.Name};
                    _db.Topping.Add(newTopping);
                    _db.SaveChanges();//add to topping table

                    //newPizzaTopping.PizzaId = newPizza.PizzaId;
                    //newPizzaTopping.ToppingId = newTopping.ToppingId;
                    //_db.PizzaTopping.Add(newPizzaTopping);
                    //_db.SaveChanges();//add to PizzaTopping table

                    //newOPT.OrderId = orderNum.OrderId;
                    //newOPT.StoreId = storeNum.StoreId;
                    //newOPT.UserId = userNum.UserId;
                    //newOPT.PizzaToppingId = newPizzaTopping.PizzaToppingId;
                    //_db.OrdersPizzaTopping.Add(newOPT); //add to OPT table
                    //_db.SaveChanges(); //git commit equiv for db
               }
          }

          public void CreateOrder(domain.Order order)
          {
               var newOrder = new Orders()
               {
                    OrderDate = order.DateOrdered,
               };
               _db.Orders.Add(newOrder);
               _db.SaveChanges();
          }

          public void CreateStore(domain.Store store)
          {
               var newStore = new Store(){Name = store.Name};
               _db.Store.Add(newStore);
               _db.SaveChanges();
          }

          public void CreateUser(domain.User user)
          {
               var newUser = new Users()
               {
                    Name = user.Name,
                    Pword = user.Password,
               };
               _db.Users.Add(newUser);
               _db.SaveChanges();
          }

          public List<domain.Pizza> ReadAll()
          {
               var pizzaWithSize = _db.Pizza.Include(t => t.Name).Include(t => t.Size).ThenInclude(t => t.Name);              
               var pizzaWithCrust = _db.Pizza.Include(t => t.Name).Include(t => t.Crust).ThenInclude(t => t.Name);
               var pizzaWithTopping = _db.PizzaTopping.Include(t => t.Topping).ThenInclude(t => t.Name).Include(t => t.Pizza).ThenInclude(t => t.Name);
               var domainPizzaList = new List<domain.Pizza>();
               //_db.Pizza.Where(f => f.PizzaId == 1);
               foreach(var item in pizzaWithCrust.ToList())
               {
                  domain.Pizza za = new domain.Pizza
                  {
                    Crust = new domain.Crust{Name = item.Crust.Name},
                    Size = new domain.Size{Name = item.Size.Name},
                    Name = new domain.Name{PizzaName = item.Name},
                  };
                  //List<domain.Topping> top = new List<domain.Topping>()
                  foreach(var item2 in pizzaWithTopping.ToList())
                  {
                       za.Toppings.Add(new domain.Topping{Name = item2.Topping.Name});
                  }

               }
               return domainPizzaList;
          }
          public void Update()
          {
               
          }
          public void Delete()
          {
               
          }
     }
}