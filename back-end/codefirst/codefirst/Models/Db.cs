using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using codefirst.Models;

namespace codefirst.Models
{
    public class Db:DbContext
    {
        public Db(DbContextOptions options) : base(options)
        { }

        public DbSet<Major> Majors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
