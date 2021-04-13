using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zad3.NET.Models;

namespace zad3.NET.Data
{
    public class List : DbContext
    {
        public List(DbContextOptions options) : base(options) { }
        public DbSet<FizzBuzz> FizzBuzz { get; set; }
    }
}
