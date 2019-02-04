using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AUD3MOJA.Models
{
    public class MoviesDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MoviesDbContext() : base("name=MoviesDbContext")
        {
        }

        public System.Data.Entity.DbSet<AUD3MOJA.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<AUD3MOJA.Models.Client> Clients { get; set; }
    }
}
