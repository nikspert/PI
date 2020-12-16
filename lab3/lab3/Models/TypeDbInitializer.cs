using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab1.Models
{
    public class TypeDbInitializer : DropCreateDatabaseAlways<TypeContext>
    {
        protected override void Seed(TypeContext db)
        {
            db.Types.Add(new Type
            {
                Name = "Базове",
                Price = 220
            });
            db.Types.Add(new Type
            {
                Name = "Розширене",
                Price = 360
            });
            db.Types.Add(new Type
            {
                Name = "Повне",
                Price = 620
            });

            base.Seed(db);

        }
    }
}