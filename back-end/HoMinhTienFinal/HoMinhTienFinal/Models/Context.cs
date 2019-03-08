using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoMinhTienFinal.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<CheckOut> CheckOuts { get; set; }
        public DbSet<CheckOutDetail> CheckOutDetails { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
}
