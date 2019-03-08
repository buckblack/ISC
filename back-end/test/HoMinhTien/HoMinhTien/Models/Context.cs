using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoMinhTien.Models;

namespace HoMinhTien.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Major> Major { get; set; }
    }
}
