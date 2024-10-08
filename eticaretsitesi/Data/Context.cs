﻿using eticaretsitesi.Models;
using Microsoft.EntityFrameworkCore;

namespace eticaretsitesi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options):base(options)
        {}
        public DbSet<Category>Categories { get; set; }
        public DbSet<Advert>Adverts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }    
    }
}
