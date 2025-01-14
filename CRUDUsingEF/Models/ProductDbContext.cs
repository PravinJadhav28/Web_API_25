using CRUDUsingEF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDUsingEF.Models
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}