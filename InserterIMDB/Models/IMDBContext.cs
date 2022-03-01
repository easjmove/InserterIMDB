using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InserterIMDB.Models
{
    public partial class IMDBContext : DbContext
    {
        public IMDBContext()
        {
        }

        public IMDBContext(DbContextOptions<IMDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TitleBasic> TitlesBasics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=IMDB;User Id=IMDB_inserter;password=p4SSw0rd;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Danish_Norwegian_CI_AS");

            modelBuilder.Entity<TitleBasic>(entity =>
            {
                entity.HasKey(e => e.tconst);

                entity.ToTable("TitlesBasic");

                entity.HasIndex(e => e.titleType, "IX_TitlesBasic");

                entity.Property(e => e.tconst)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.originalTitle)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.primaryTitle)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.titleType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
