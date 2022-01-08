using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;

namespace MusicAPI.Contexts
{
    public class AlbumContext : DbContext
    {

        public AlbumContext(DbContextOptions<AlbumContext> options) : base(options)
        {

        }

        public DbSet<AlbumModel> Albums { get; set; }

        public DbSet<SongModel> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumModel>()
                .HasMany(b => b.Songs);
        }

    }
}
