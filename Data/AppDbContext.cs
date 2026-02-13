using Microsoft.EntityFrameworkCore;
using SchoolManagerMVC.Models;

namespace SchoolManagerMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Ucenik> Ucenici { get; set; }
        public DbSet<Razred> Razredi { get; set; }
    }
}