using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Pword { get; set; }
        public int? Optid { get; set; }

        public virtual OrdersPizzaTopping Opt { get; set; }
    }
}
