using Microsoft.EntityFrameworkCore;

namespace MontyHallApi.Entities
{
    public class SimulationDbContext : DbContext
    {
        public SimulationDbContext(DbContextOptions<SimulationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SimulationResult> SimulationResults { get; set; }
    }
}
