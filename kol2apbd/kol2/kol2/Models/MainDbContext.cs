using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {

        }
        public MainDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Musician>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                m.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                m.Property(e => e.Nickname).HasMaxLength(20);

                m.HasData(
                    new Musician { IdMusician = 1, FirstName = "Tomasz", LastName = "Blok", Nickname = "tomaszek"},
                    new Musician { IdMusician = 2, FirstName = "Michal", LastName = "Kwiatek", Nickname = "michalek"}
                    );
            });
            modelBuilder.Entity<Musician_Track>(m =>
            {
                m.HasKey(e => new
                {
                    e.IdMusician,
                    e.IdTrack
                });
                m.HasOne(e => e.Musician).WithMany(e => Musician_Tracks).HasForeignKey(e => e.IdMusician);
                m.HasOne(e => e.Track).WithMany(e => Musician_Tracks).HasForeignKey(e => e.IdTrack);

                m.HasData(
                    new Musician_Track { IdTrack = 1, IdMusician = 1},
                    new Musician_Track { IdTrack = 2, IdMusician = 1},
                    new Musician_Track { IdTrack = 3, IdMusician = 1},
                    new Musician_Track { IdTrack = 4, IdMusician = 1},
                    new Musician_Track { IdTrack = 5, IdMusician = 2},
                    new Musician_Track { IdTrack = 6, IdMusician = 2}
                    );
            });
            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                t.Property(e => e.Duration).IsRequired();

                t.HasOne(e => e.Album).WithMany(e => Tracks).HasForeignKey(e => e.IdMusicAlbum);

                t.HasData(
                    new Track { IdTrack = 1, TrackName = "utwor1aaa", Duration = 3, IdMusicAlbum = 1 },
                    new Track { IdTrack = 2, TrackName = "utwor2aaa", Duration = 2, IdMusicAlbum = 1 },
                    new Track { IdTrack = 3, TrackName = "utwor1bbb", Duration = 1, IdMusicAlbum = 2 },
                    new Track { IdTrack = 4, TrackName = "utwor2bbb", Duration = 4, IdMusicAlbum = 2 },
                    new Track { IdTrack = 5, TrackName = "utwor1ccc", Duration = 2, IdMusicAlbum = 3 },
                    new Track { IdTrack = 6, TrackName = "utwor2ccc", Duration = 6, IdMusicAlbum = 3 }
                    );

            });
            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(e => e.IdAlbum);
                a.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                a.Property(e => e.PublishDate).IsRequired();

                a.HasOne(e => e.MusicLabel).WithMany(e => Albums).HasForeignKey(e => e.IdMusicLabel);

                a.HasData(
                    new Album { IdAlbum = 1, AlbumName = "aaa", PublishDate = DateTime.Parse("2022-06-08"), IdMusicLabel = 1},
                    new Album { IdAlbum = 2, AlbumName = "bbb", PublishDate = DateTime.Parse("2022-05-21"), IdMusicLabel = 2},
                    new Album { IdAlbum = 3, AlbumName = "ccc", PublishDate = DateTime.Parse("2021-11-01"), IdMusicLabel = 3}
                    );
            });
            modelBuilder.Entity<MusicLabel>(m =>
            {
                m.HasKey(e => e.IdMusicLabel);
                m.Property(e => e.Name).IsRequired().HasMaxLength(50);

                m.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "sbm"},
                    new MusicLabel { IdMusicLabel = 2, Name = "UMG"},
                    new MusicLabel { IdMusicLabel = 3, Name = "defjam"}
                    );
            });
        }

    }
}
