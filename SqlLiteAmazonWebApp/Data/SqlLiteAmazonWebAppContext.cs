using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SqlLiteAmazonWebApp.Models;

namespace SqlLiteAmazonWebApp.Data
{
    public class SqlLiteAmazonWebAppContext : DbContext
    {
        public SqlLiteAmazonWebAppContext (DbContextOptions<SqlLiteAmazonWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Categorie> Categorie { get; set; } = default!;

        public DbSet<Product> Product { get; set; } = default!;
    }
}
