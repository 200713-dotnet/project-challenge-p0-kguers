using System;

namespace PizzaStore.Domain.Models
{
     public class Name 
     {
         public string UName {get; set;}

         public Name(string name)
         {
              UName = name;
         }
     }
}