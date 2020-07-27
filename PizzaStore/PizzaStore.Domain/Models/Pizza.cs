using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
     public class Pizza
     {
          public List<Topping> Toppings { get; set; }
          public Crust Crust { get; set; }
          public Size Size { get; set; }
          public string Name { get; set; }

          public decimal Price{ get; }

          // public decimal CalculatePrice()
          // {
          //      return total;
          // }
          
          public override string ToString() 
          {
               return $"{Name} \n {Crust.Name}\n{Size.Name}";
          }
     }
}