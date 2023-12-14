using Microsoft.EntityFrameworkCore;
using Neat.Data.Models;

namespace Neat.Data {
    public class NeatDbContext : DbContext {
        public NeatDbContext() { }
        public NeatDbContext(DbContextOptions options) : base(options) {}

        public virtual DbSet<Asset> Assets { get; set; }
    }
}