using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1.Models
{
    public class Type
    { 
    public int Id { get; set; }

    public string Name { get; set; }
   
    public int Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Type()
        {
          Orders = new List<Order>();
        }
    }
}