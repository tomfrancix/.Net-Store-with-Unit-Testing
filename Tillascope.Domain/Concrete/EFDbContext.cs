using System;
using Tillascope.Domain.Entities;
using System.Data.Entity;

namespace Tillascope.Domain.Concrete
{
    
    /// To use the code first feature I have created a class that is derived from System.Data.Entity.DbContext
    public class EFDbContext : DbContext
    {
        // The DbContext class automatically defines a property for each table in the database
        public DbSet<Product> Products { get; set;  }

        //The 'name' (Products) specifies the Database Table. The 'type' (Product) specifies the model class for the table.

        // Next, we need to tell Entity Framework how to connect to the database --- web.config (code:100)
    }
}
