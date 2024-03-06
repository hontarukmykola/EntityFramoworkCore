

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicСollection
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public DateTime DataCreate { get; set; }
        [Required, MaxLength(100)]
        public ICollection<Track> Tracks { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public int? Rating { get; set; }
    }
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Surname { get; set; }

        [Required, MaxLength(100)]
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
    public class Track
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
        [Required, MaxLength(100)]
        public string Duration { get; set; }
        public Playlist Playlist { get; set; }
        public int PlaylistId { get; set; }
        public int? Rating { get; set; }
        public int? CountOfReadings { get; set; }
        public string Text { get; set; }

    }

    public class MusicCollectionDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-L9K9OL7\SQLEXPRESS;
                                        Initial Catalog = MusicCollection;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;
                                        Trust Server Certificate=False;
                                        Application Intent=ReadWrite;
                                        Multi Subnet Failover=False");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(a => a.Albums)
                .HasForeignKey(a => a.ArtistId);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Genre)
                .WithMany(a => a.Albums)
                .HasForeignKey(a => a.GenreId);

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Tracks)
                .WithMany(a => a.Albums);

            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Country)
                .WithMany(a => a.Artists)
                .HasForeignKey(a => a.CountryId);

            modelBuilder.Entity<Playlist>()
                .HasOne(a => a.Category)
                .WithMany(a => a.Playlists)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Track>()
                 .HasOne(a => a.Playlist)
                 .WithMany(a => a.Tracks)
                 .HasForeignKey(a => a.PlaylistId);


            modelBuilder.SeedCountry();
            modelBuilder.SeedCategory();
            modelBuilder.SeedGenre();
            modelBuilder.SeedArtist();
            modelBuilder.SeedPlaylist();
            modelBuilder.SeedTrack();
            modelBuilder.SeedAlbum();
        }
    }
}
