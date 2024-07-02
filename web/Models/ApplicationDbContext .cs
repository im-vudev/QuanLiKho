using Microsoft.EntityFrameworkCore;
using web.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<DonViTinh> DonViTinhs { get; set; }
    public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
    public DbSet<SanPham> SanPhams { get; set; }
    public DbSet<NCC> NCCs { get; set; }
    public DbSet<Kho> Khos { get; set; }
    public DbSet<KhoUser> KhoUsers { get; set; }
    public DbSet<NhapKho> NhapKhos { get; set; }
    public DbSet<NhapKhoRawData> NhapKhoRawDatas { get; set; }
    public DbSet<XuatKho> XuatKhos { get; set; }
    public DbSet<XuatKhoRawData> XuatKhoRawDatas { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DonViTinh>()
            .HasIndex(d => d.Ten_Don_Vi_Tinh)
            .IsUnique();

        modelBuilder.Entity<LoaiSanPham>()
            .HasIndex(l => l.Ma_LSP)
            .IsUnique();

        modelBuilder.Entity<LoaiSanPham>()
            .HasIndex(l => l.Ten_LSP)
            .IsUnique();

        modelBuilder.Entity<SanPham>()
            .HasIndex(s => s.Ma_San_Pham)
            .IsUnique();

        modelBuilder.Entity<NCC>()
            .HasIndex(n => n.Ten_NCC)
            .IsUnique();

        modelBuilder.Entity<Kho>()
            .HasIndex(k => k.Ten_Kho)
            .IsUnique();

        modelBuilder.Entity<KhoUser>()
      .HasIndex(c => new { c.UserId, c.KhoId })
      .IsUnique();

        modelBuilder.Entity<NhapKho>()
            .HasIndex(n => n.SoPhieuNhapKho)
            .IsUnique();

        modelBuilder.Entity<XuatKho>()
            .HasIndex(x => x.SoPhieuXuatKho)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Ma_Dang_Nhap)
            .IsUnique();

        modelBuilder.Entity<KhoUser>()
     .HasOne(ku => ku.User)
     .WithMany(u => u.KhoUsers)
     .HasForeignKey(ku => ku.UserId)
     .HasPrincipalKey(u => u.Auto_ID);

        modelBuilder.Entity<KhoUser>()
            .HasOne(ku => ku.Kho)
            .WithMany(k => k.KhoUsers)
            .HasForeignKey(ku => ku.KhoId)
            .HasPrincipalKey(k => k.Auto_ID);

        modelBuilder.Entity<XuatKho>()
            .HasOne(xk => xk.Kho)
            .WithMany(k => k.XuatKhos)
            .HasForeignKey(xk => xk.KhoId)
            .HasPrincipalKey(k => k.Auto_ID);

        modelBuilder.Entity<NhapKho>()
            .HasOne(nk => nk.Kho)
            .WithMany(k => k.NhapKhos)
            .HasForeignKey(nk => nk.KhoId)
            .HasPrincipalKey(k => k.Auto_ID);

        modelBuilder.Entity<NhapKho>()
            .HasOne(nk => nk.NCC)
            .WithMany(n => n.NhapKhos)
            .HasForeignKey(nk => nk.NCC_Id)
            .HasPrincipalKey(n => n.Auto_ID);
    }
}
