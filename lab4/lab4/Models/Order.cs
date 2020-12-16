using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1.Models
{
    public class Order
    {

        public int OrderId { get; set; }

        public string Person { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Type> Types { get; set; }
        public Order()
        {
            Types = new List<Type>();
        }
        public DateTime Date { get; set; }
    }
}