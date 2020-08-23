using JosephCode.Models;
using Microsoft.EntityFrameworkCore;

namespace JosephCode.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Wolve> Wolves { get; set; }

         public DbSet<Pack> Packs { get; set; }
        
    }
}