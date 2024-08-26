using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLKHOXD.Models;

public partial class QlkhoxaydungContext : DbContext
{
    public QlkhoxaydungContext()
    {
    }

    public QlkhoxaydungContext(DbContextOptions<QlkhoxaydungContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

    public virtual DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }

    public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    public virtual DbSet<VatTu> VatTus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Rotdeptrai;Initial Catalog=QLKHOXAYDUNG;User ID=sa;Password=123456;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
        {
            entity.HasKey(e => new { e.MaPn, e.MaVt }).HasName("PK__ChiTietP__D557B6F31DFC6F15");

            entity.ToTable("ChiTietPhieuNhap");

            entity.Property(e => e.MaPn).HasColumnName("MaPN");
            entity.Property(e => e.MaVt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaVT");
            entity.Property(e => e.NgaySx).HasColumnName("NgaySX");

            entity.HasOne(d => d.MaPnNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaPn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPhi__MaPN__412EB0B6");

            entity.HasOne(d => d.MaVtNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaVt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPhi__MaVT__4222D4EF");
        });

        modelBuilder.Entity<ChiTietPhieuXuat>(entity =>
        {
            entity.HasKey(e => new { e.MaPx, e.MaVt }).HasName("PK__ChiTietP__D557B6C9C183D550");

            entity.ToTable("ChiTietPhieuXuat");

            entity.Property(e => e.MaPx).HasColumnName("MaPX");
            entity.Property(e => e.MaVt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaVT");

            entity.HasOne(d => d.MaPxNavigation).WithMany(p => p.ChiTietPhieuXuats)
                .HasForeignKey(d => d.MaPx)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPhi__MaPX__47DBAE45");

            entity.HasOne(d => d.MaVtNavigation).WithMany(p => p.ChiTietPhieuXuats)
                .HasForeignKey(d => d.MaVt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPhi__MaVT__48CFD27E");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NguoiDun__2725D70A250674D4");

            entity.ToTable("NguoiDung");

            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.IdVaitro).HasColumnName("ID_VAITRO");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TaiKhoan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai).HasMaxLength(30);

            entity.HasOne(d => d.IdVaitroNavigation).WithMany(p => p.NguoiDungs)
                .HasForeignKey(d => d.IdVaitro)
                .HasConstraintName("FK__NguoiDung__ID_VA__398D8EEE");
        });

        modelBuilder.Entity<PhieuNhap>(entity =>
        {
            entity.HasKey(e => e.MaPn).HasName("PK__PhieuNha__2725E7F056BC13B0");

            entity.ToTable("PhieuNhap");

            entity.Property(e => e.MaPn).HasColumnName("MaPN");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.TrangThai).HasMaxLength(30);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PhieuNhap__MaNV__3E52440B");
        });

        modelBuilder.Entity<PhieuXuat>(entity =>
        {
            entity.HasKey(e => e.MaPx).HasName("PK__PhieuXua__2725E7CA845EAE74");

            entity.ToTable("PhieuXuat");

            entity.Property(e => e.MaPx).HasColumnName("MaPX");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.MaNguoiNhan)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.TrangThai).HasMaxLength(30);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuXuats)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PhieuXuat__MaNV__44FF419A");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.IdVaitro).HasName("PK__VaiTro__86F820A6CF9A9F8A");

            entity.ToTable("VaiTro");

            entity.Property(e => e.IdVaitro)
                .ValueGeneratedNever()
                .HasColumnName("ID_VAITRO");
            entity.Property(e => e.Mota)
                .HasMaxLength(100)
                .HasColumnName("MOTA");
            entity.Property(e => e.TenVaitro)
                .HasMaxLength(50)
                .HasColumnName("TEN_VAITRO");
        });

        modelBuilder.Entity<VatTu>(entity =>
        {
            entity.HasKey(e => e.MaVt).HasName("PK__VatTu__2725103E0F740E7B");

            entity.ToTable("VatTu");

            entity.Property(e => e.MaVt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaVT");
            entity.Property(e => e.Donvitinh).HasMaxLength(20);
            entity.Property(e => e.Mota).HasMaxLength(50);
            entity.Property(e => e.TenVt)
                .HasMaxLength(50)
                .HasColumnName("TenVT");
            entity.Property(e => e.TinhTrangVt)
                .HasMaxLength(50)
                .HasColumnName("TinhTrangVT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
