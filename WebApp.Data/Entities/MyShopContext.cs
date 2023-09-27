using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Data.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Length { get; set; } 
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class MyShopContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public MyShopContext() { }
    public MyShopContext(DbContextOptions options) : base(options)
    {
    }
}
