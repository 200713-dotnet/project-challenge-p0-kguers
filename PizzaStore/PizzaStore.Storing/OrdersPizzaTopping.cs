using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class OrdersPizzaTopping
    {
        public OrdersPizzaTopping()
        {
            Store = new HashSet<Store>();
            Users = new HashSet<Users>();
        }

        public int Optid { get; set; }
        public int? OrderId { get; set; }
        public int? PizzaToppingId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual PizzaTopping PizzaTopping { get; set; }
        public virtual ICollection<Store> Store { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
