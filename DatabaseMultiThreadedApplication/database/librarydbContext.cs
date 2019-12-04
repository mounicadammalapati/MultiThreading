using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseMultiThreadedApplication.database
{
    public partial class librarydbContext : DbContext
    {
        public librarydbContext()
        {
        }

        public librarydbContext(DbContextOptions<librarydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonDetails> PersonDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=IS-HWILSTEAD;Database=librarydb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.Bookid);

                entity.Property(e => e.Bookid).HasColumnName("bookid");

                entity.Property(e => e.Bookname)
                    .HasColumnName("bookname")
                    .HasMaxLength(20);

                entity.Property(e => e.Libraryid).HasColumnName("libraryid");

                entity.HasOne(d => d.Library)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Libraryid)
                    .HasConstraintName("FK__Books__libraryid__412EB0B6");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.Property(e => e.Libraryid).HasColumnName("libraryid");

                entity.Property(e => e.Librarylocation).HasColumnName("librarylocation");

                entity.Property(e => e.Libraryname).HasColumnName("libraryname");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.Property(e => e.Bookid).HasColumnName("bookid");

                entity.Property(e => e.PersonName).HasMaxLength(20);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.Bookid)
                    .HasConstraintName("FK__person__bookid__440B1D61");
            });

            modelBuilder.Entity<PersonDetails>(entity =>
            {
                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");
            });
        }
    }
}
