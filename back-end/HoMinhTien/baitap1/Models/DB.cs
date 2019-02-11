using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baitap1.Models
{
    public class DB:DbContext
    {
        public DB(DbContextOptions<DB> options):base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Receipt_Item> Receipt_Items { get; set; }
    }
}
