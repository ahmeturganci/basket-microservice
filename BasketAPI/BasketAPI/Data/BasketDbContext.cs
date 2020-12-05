
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BasketAPI.Data.Entities;

namespace BasketAPI.Data
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options)
            : base(options)
        {


        }
        public virtual DbSet<BasketItem> BasketItems { get; set; }

    }
}
