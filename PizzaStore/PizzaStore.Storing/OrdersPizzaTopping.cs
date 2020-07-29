using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class OrdersPizzaTopping
    {
        public int Optid { get; set; }
        public int? OrderId { get; set; }
        public int? UserId { get; set; }
        public int? StoreId { get; set; }
        public int? PizzaToppingId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual PizzaTopping PizzaTopping { get; set; }
        public virtual Store Store { get; set; }
        public virtual Users User { get; set; }
    }
}
