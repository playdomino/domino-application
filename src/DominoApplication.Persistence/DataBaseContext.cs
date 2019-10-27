using DominoApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DominoApplication.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<GamePlayer>()
                .HasKey(p=> new { p.GameId,p.PlayerId});
            modelBuilder.Entity<GamePlayer>()
                .HasOne(p => p.Game)
                .WithMany(p => p.GamePlayers)
                .HasForeignKey(p=>p.GameId);
            modelBuilder.Entity<GamePlayer>()
                .HasOne(p => p.Player)
                .WithMany(p => p.GamePlayers)
                .HasForeignKey(p => p.PlayerId);
        }
    }
}
