using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;

namespace MusicAPI.Contexts
{
    public class AlbumContext : DbContext
    {
        public AlbumContext() : base()
        {

        }

        public DbSet<AlbumModel> Albums { get; set; }

        public DbSet<SongModel> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KYLE;Database=MusicDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumModel>()
                .HasMany(b => b.Songs);
        }

    }
}
