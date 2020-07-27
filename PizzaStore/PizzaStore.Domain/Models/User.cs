using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
     public class User
     {
          public List<Order> Orders {get; set;}
          public Name Name { get; set; }
          
          // public User(string name, string username, string password)
          // {
          //      Orders = new List<Order>();
          //      Name = new Name(name);
          // }
          public User()
          {
               Orders = new List<Order>();
          }
     }
}