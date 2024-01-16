using Microsoft.EntityFrameworkCore;
using Neat.Data.Models;

namespace Neat.Data {
    public class NeatDbContext : DbContext {
        public NeatDbContext() { }
        public NeatDbContext(DbContextOptions options) : base(options) {}

        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<AssetType> AssetTypes { get; set; }
    }
}