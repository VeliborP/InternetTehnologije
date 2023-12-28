using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InternetTehnologije.DAL
{
    public partial class InternetTehnologijeContext : DbContext
    {
        public InternetTehnologijeContext()
        {
        }

        public InternetTehnologijeContext(DbContextOptions<InternetTehnologijeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Predmet> Predmets { get; set; }
        public virtual DbSet<PredmetSmer> PredmetSmers { get; set; }
        public virtual DbSet<Smer> Smers { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=InternetTehnologije;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Predmet>(entity =>
            {
                entity.ToTable("Predmet");

                entity.Property(e => e.Espb).HasColumnName("ESPB");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sifra)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PredmetSmer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PredmetSmer");

                entity.HasOne(d => d.Predmet)
                    .WithMany()
                    .HasForeignKey(d => d.PredmetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Predmet_Smer");

                entity.HasOne(d => d.Smer)
                    .WithMany()
                    .HasForeignKey(d => d.SmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PredmetSmer_Smer");
            });

            modelBuilder.Entity<Smer>(entity =>
            {
                entity.ToTable("Smer");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sifra)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.BrojIndeksa)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Smer)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SmerId)
                    .HasConstraintName("FK_Student_Smer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
