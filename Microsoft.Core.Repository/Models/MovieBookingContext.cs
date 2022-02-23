using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.Core.Repository.Models
{
    public partial class MovieBookingContext : DbContext
    {
        public MovieBookingContext()
        {
        }

        public MovieBookingContext(DbContextOptions<MovieBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingHistory> BookingHistories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MovieGenre> MovieGenres { get; set; } = null!;
        public virtual DbSet<MovieLanguage> MovieLanguages { get; set; } = null!;
        public virtual DbSet<MovieType> MovieTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleMapper> RoleMappers { get; set; } = null!;
        public virtual DbSet<SeatClass> SeatClasses { get; set; } = null!;
        public virtual DbSet<SeatMapper> SeatMappers { get; set; } = null!;
        public virtual DbSet<Show> Shows { get; set; } = null!;
        public virtual DbSet<ShowTiming> ShowTimings { get; set; } = null!;
        public virtual DbSet<ShowsMapper> ShowsMappers { get; set; } = null!;
        public virtual DbSet<Theatre> Theatres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MovieBooking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingHistory>(entity =>
            {
                entity.ToTable("BookingHistory");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.MovieShowDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BookingHistories)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__BookingHi__Custo__47DBAE45");

                entity.HasOne(d => d.SeatMapper)
                    .WithMany(p => p.BookingHistories)
                    .HasForeignKey(d => d.SeatMapperId)
                    .HasConstraintName("FK__BookingHi__SeatM__48CFD27E");

                entity.HasOne(d => d.ShowsMapper)
                    .WithMany(p => p.BookingHistories)
                    .HasForeignKey(d => d.ShowsMapperId)
                    .HasConstraintName("FK__BookingHi__Shows__49C3F6B7");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasOne(d => d.Genres)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenresId)
                    .HasConstraintName("FK__Movies__GenresId__2E1BDC42");

                entity.HasOne(d => d.Langauge)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.LangaugeId)
                    .HasConstraintName("FK__Movies__Langauge__2C3393D0");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK__Movies__TypeId__2D27B809");
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.Property(e => e.Genres).HasMaxLength(32);
            });

            modelBuilder.Entity<MovieLanguage>(entity =>
            {
                entity.ToTable("MovieLanguage");

                entity.Property(e => e.Language).HasMaxLength(16);
            });

            modelBuilder.Entity<MovieType>(entity =>
            {
                entity.ToTable("MovieType");

                entity.Property(e => e.Type).HasMaxLength(16);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Role1)
                    .HasMaxLength(50)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<RoleMapper>(entity =>
            {
                entity.ToTable("RoleMapper");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RoleMappers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__RoleMappe__Custo__60A75C0F");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleMappers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__RoleMappe__RoleI__5FB337D6");
            });

            modelBuilder.Entity<SeatClass>(entity =>
            {
                entity.ToTable("SeatClass");

                entity.Property(e => e.ClassType).HasMaxLength(16);
            });

            modelBuilder.Entity<SeatMapper>(entity =>
            {
                entity.ToTable("SeatMapper");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.SeatClass)
                    .WithMany(p => p.SeatMappers)
                    .HasForeignKey(d => d.SeatClassId)
                    .HasConstraintName("FK__SeatMappe__SeatC__3B75D760");

                entity.HasOne(d => d.ShowTimings)
                    .WithMany(p => p.SeatMappers)
                    .HasForeignKey(d => d.ShowTimingsId)
                    .HasConstraintName("FK__SeatMappe__ShowT__5AEE82B9");

                entity.HasOne(d => d.Theater)
                    .WithMany(p => p.SeatMappers)
                    .HasForeignKey(d => d.TheaterId)
                    .HasConstraintName("FK__SeatMappe__Theat__3A81B327");
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__Shows__MovieId__4222D4EF");

                entity.HasOne(d => d.ShowTimings)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.ShowTimingsId)
                    .HasConstraintName("FK__Shows__ShowTimin__403A8C7D");

                entity.HasOne(d => d.Theatre)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.TheatreId)
                    .HasConstraintName("FK__Shows__TheatreId__412EB0B6");
            });

            modelBuilder.Entity<ShowsMapper>(entity =>
            {
                entity.ToTable("ShowsMapper");

                entity.Property(e => e.MovieShowDate).HasColumnType("datetime");

                entity.HasOne(d => d.Shows)
                    .WithMany(p => p.ShowsMappers)
                    .HasForeignKey(d => d.ShowsId)
                    .HasConstraintName("FK__ShowsMapp__Shows__44FF419A");
            });

            modelBuilder.Entity<Theatre>(entity =>
            {
                entity.ToTable("Theatre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
