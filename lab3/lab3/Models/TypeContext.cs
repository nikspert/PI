using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab1.Models
{
    public class TypeContext : DbContext
    {
        
            public DbSet<Type> Types { get; set; }
            public DbSet<Order> Orders { get; set; }
        
    }
}