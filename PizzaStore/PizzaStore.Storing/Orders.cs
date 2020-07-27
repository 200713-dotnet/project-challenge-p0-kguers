using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersPizzaTopping = new HashSet<OrdersPizzaTopping>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual ICollection<OrdersPizzaTopping> OrdersPizzaTopping { get; set; }
    }
}
