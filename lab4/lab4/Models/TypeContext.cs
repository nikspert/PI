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
        
    
            public TypeContext() : base("DefaultConnection")
            { }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Order>().HasMany(c => c.Types)
                    .WithMany(s => s.Orders)
                    .Map(t => t.MapLeftKey("OrderId")
                    .MapRightKey("TypeId")
                    .ToTable("OrderType"));
            }

    }
}