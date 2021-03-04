using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TwoThreadsApplication.dbmodels
{
    public partial class PetShelterContext : DbContext
    {
        public PetShelterContext()
        {
        }

        public PetShelterContext(DbContextOptions<PetShelterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Petshelter> Petshelter { get; set; }
        public virtual DbSet<Shelter> Shelter { get; set; }
        public virtual DbSet<State> State { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PetShelter;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Petshelter>(entity =>
            {
                entity.ToTable("petshelter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Lastupdated)
                    .HasColumnName("lastupdated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShelterId).HasColumnName("shelterId");

                entity.HasOne(d => d.Shelter)
                    .WithMany(p => p.Petshelter)
                    .HasForeignKey(d => d.ShelterId)
                    .HasConstraintName("FK__petshelte__shelt__2B3F6F97");
            });

            modelBuilder.Entity<Shelter>(entity =>
            {
                entity.ToTable("shelter");

                entity.Property(e => e.Shelterid)
                    .HasColumnName("shelterid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Lastupdated)
                    .HasColumnName("lastupdated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sheltername)
                    .HasColumnName("sheltername")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Shelter)
                    .HasForeignKey(d => d.Stateid)
                    .HasConstraintName("FK__shelter__stateid__286302EC");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.Stateid)
                    .HasColumnName("stateid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("lastupdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Statename)
                    .HasColumnName("statename")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
