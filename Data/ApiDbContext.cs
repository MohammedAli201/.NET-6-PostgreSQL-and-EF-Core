using Microsoft.EntityFrameworkCore;
using PostgresDB.Models;

namespace PostgresDB.Data
{


    public class ApiDbContext : DbContext
    {
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Media> Medias { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Drivers>(entity =>
            {
                entity.HasOne(t => t.Team)
                    .WithMany(d => d.Drivers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Drivers_Team");

                entity.HasOne(m => m.Media)
                .WithOne(d => d.Driver)
                .HasForeignKey<Media>(m => m.DriverId);


            });


        }
    }
}