﻿using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Users
    {
        public Users()
        {
            OrdersPizzaTopping = new HashSet<OrdersPizzaTopping>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Pword { get; set; }

        public virtual ICollection<OrdersPizzaTopping> OrdersPizzaTopping { get; set; }
    }
}
