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

        public DbSet<ArtistModel> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumModel>()
                .HasOne(x => x.Artist)
                .WithMany(x => x.Albums);

            modelBuilder.Entity<AlbumModel>()
                .HasMany(x => x.Songs);

        }

    }
}
