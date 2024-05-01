using Microsoft.EntityFrameworkCore;
using Apirest.Models;

namespace Apirest.Data
{
    public class DataContext : DbContext
    {   
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Note> Notes { get; set; }
    }
}