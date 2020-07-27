using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pword { get; set; }
        public int? Optid { get; set; }

        public virtual OrdersPizzaTopping Opt { get; set; }
    }
}
