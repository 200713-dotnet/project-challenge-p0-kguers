using System;
using System.Collections.Generic;
using System.Linq;
using domain = PizzaStore.Domain.Models;

namespace PizzaStore.Storing.Repositories
{
     public class PizzaRepository
     {
         
          // private PizzaBoxDbContext _db = new PizzaBoxDbContext();
          // public void Create(domain.Pizza pizza)
          // {
          //      var newPizza = new Pizza();

          //      newPizza.Crust = new Crust() {Name = pizza.Crust.Name};
          //      newPizza.Size = new Size() {Name = pizza.Size.Name}
          //      newPizza.Name = pizza.Name;

          //      _db.Pizza.Add(newPizza); //git add equiv for db
          //      _db.SaveChanges(); //git commit equiv for db
          // }
          // public List<Pizza> ReadAll()
          // {
          //      var domainPizzaList = new List<domain.Pizza>();
          //      foreach(var item in _db.Pizza.ToList())
          //      {
          //           domainPizzaList.Add(new domain.Pizza()
          //           {
          //                Crust = new domain.Crust() {Name = item.Crust.Name },
          //                Size = new domain.Size() {Name = item.Size.Name },
          //                Toppings = new List<domain.Topping>()
          //           });
          //      }
          // }
          public void Update()
          {
               
          }
          public void Delete()
          {

          }
     }
}