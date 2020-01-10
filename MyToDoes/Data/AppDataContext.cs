
using Microsoft.EntityFrameworkCore;
using MyToDoes.Models;

namespace MyToDoes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ToDo> ToDoes { get; set; }

        
    }
}
