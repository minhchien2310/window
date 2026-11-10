using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QLHH1.Models
{
    public partial class QLHH1Context : DbContext
    {
        public QLHH1Context()
        {
        }

        public QLHH1Context(DbContextOptions<QLHH1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Phieuthue> Phieuthues { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=localhost;Database=QLHH1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KHACHHAN__2725CF1EAB89A01C");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(10)
                    .HasColumnName("MaKH");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(100)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<Phieuthue>(entity =>
            {
                entity.HasKey(e => e.MaPt)
                    .HasName("PK__PHIEUTHU__2725E7F6737A3E14");

                entity.ToTable("PHIEUTHUE");

                entity.Property(e => e.MaPt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaPT");

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(10)
                    .HasColumnName("MaKH");

                entity.Property(e => e.NgayThue).HasColumnType("date");

                entity.Property(e => e.NgayTra).HasColumnType("date");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Phieuthues)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_PHIEUTHUE_KHACHHANG");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
