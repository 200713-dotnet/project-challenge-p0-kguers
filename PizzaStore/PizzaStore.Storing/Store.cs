using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Store
    {
        public Store()
        {
            OrdersPizzaTopping = new HashSet<OrdersPizzaTopping>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrdersPizzaTopping> OrdersPizzaTopping { get; set; }
    }
}
