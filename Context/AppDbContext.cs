using Microsoft.EntityFrameworkCore;
using Worker_CRUD.Models;

namespace Worker_CRUD.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<WorkerModel> Worker { get; set; }
    }
}
