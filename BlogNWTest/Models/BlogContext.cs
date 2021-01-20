using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNWTest.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // {
       //     optionsBuilder.UseSqlServer("Server=DESKTOP-VE5PN8N\\SQLEXPRESS;Database=blognwdb;Trusted_Connection=True");
       // }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Categorie> Categories { get; set; }
    }
}
