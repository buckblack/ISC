using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testmysql.Models
{
    public class Db : DbContext
    {
        public Db(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<Major> Majors { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
