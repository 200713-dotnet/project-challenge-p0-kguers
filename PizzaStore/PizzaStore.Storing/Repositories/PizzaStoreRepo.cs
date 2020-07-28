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
          
          public void CreatePizza(domain.Pizza pizza/*, domain.Order order*/)
          {
               
               var newPizza = new Pizza();
               var newTopping = new Topping();
               var newPizzaTopping = new PizzaTopping();
               var newOPT = new OrdersPizzaTopping();
               var newOrder = new Orders();

               //newPizza.Crust = _db.Crust.FirstOrDefault(Crust ==> Name = pizza.Crust.Name);
               newPizza.Crust = new Crust() {Name = pizza.Crust.Name};
               newPizza.Size = new Size() {Name = pizza.Size.Name};
               newPizza.Name = pizza.Name.PizzaName;
               _db.Pizza.Add(newPizza); //git add equiv for db
               _db.SaveChanges();
               foreach(var item in pizza.Toppings)
               {
                    newTopping = new Topping{Name = item.Name};
                    _db.Topping.Add(newTopping);
                    _db.SaveChanges();
                    newPizzaTopping.PizzaId = newPizza.PizzaId;
                    newPizzaTopping.ToppingId = newTopping.ToppingId;
                    _db.PizzaTopping.Add(newPizzaTopping);
                    _db.SaveChanges();
               }
               //newOrder = new Orders{}
               //_db.OrdersPizzaTopping.Add()
               _db.SaveChanges(); //git commit equiv for db
          }

          public void CreateOrder(domain.Order order)
          {
               var newOrder = new Orders();
               var newOPT = new OrdersPizzaTopping(); 
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