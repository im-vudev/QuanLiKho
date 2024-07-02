﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240626103058_DbQuanLiKhoHang")]
    partial class DbQuanLiKhoHang
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("web.Models.DonViTinh", b =>
                {
                    b.Property<int>("Auto_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Auto_ID"));

                    b.Property<string>("Ghi_Chu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten_Don_Vi_Tinh")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Auto_ID");

                    b.HasIndex("Ten_Don_Vi_Tinh")
                        .IsUnique();

                    b.ToTable("DonViTinhs");
                });

            modelBuilder.Entity("web.Models.Kho", b =>
                {
                    b.Property<int>("Auto_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Auto_ID"));

                    b.Property<string>("Ghi_Chu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten_Kho")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Auto_ID");

                    b.HasIndex("Ten_Kho")
                        .IsUnique();

                    b.ToTable("Khos");
                });

            modelBuilder.Entity("web.Models.KhoUser", b =>
                {
                    b.Property<int>("AutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoId"));

                    b.Property<int>("KhoId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.HasKey("AutoId");

                    b.HasIndex("KhoId");

                    b.HasIndex("UserId", "KhoId")
                        .IsUnique();

                    b.ToTable("KhoUsers");
                });

            modelBuilder.Entity("web.Models.LoaiSanPham", b =>
                {
                    b.Property<int>("Auto_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Auto_ID"));

                    b.Property<string>("Ghi_Chu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma_LSP")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ten_LSP")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Auto_ID");

                    b.HasIndex("Ma_LSP")
                        .IsUnique();

                    b.HasIndex("Ten_LSP")
                        .IsUnique();

                    b.ToTable("LoaiSanPhams");
                });

            modelBuilder.Entity("web.Models.NCC", b =>
                {
                    b.Property<int>("Auto_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Auto_ID"));

                    b.Property<string>("Ghi_Chu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma_NCC")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ten_NCC")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Auto_ID");

                    b.HasIndex("Ten_NCC")
                        .IsUnique();

                    b.ToTable("NCCs");
                });

            modelBuilder.Entity("web.Models.NhapKho", b =>
                {
                    b.Property<int>("Auto_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Auto_Id"));

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KhoId")
                        .HasColumnType("int");

                    b.Property<int>("NCC_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayNhapKho")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoPhieuNhapKho")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Auto_Id");

                    b.HasIndex("KhoId");

                    b.HasIndex("NCC_Id");

                    b.HasIndex("SoPhieuNhapKho")
                        .IsUnique();

                    b.ToTable("NhapKhos");
                });

            modelBuilder.Entity("web.Models.NhapKhoRawData", b =>
                {
                    b.Property<int>("AutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoId"));

                    b.Property<decimal>("DonGiaNhap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NhapKhoId")
                        .HasColumnType("int");

                    b.Property<int>("SLNhap")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.HasKey("AutoId");

                    b.HasIndex("NhapKhoId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("NhapKhoRawDatas");
                });

            modelBuilder.Entity("web.Models.SanPham", b =>
                {
                    b.Property<int>("Auto_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Auto_ID"));

                    b.Property<int>("Don_Vi_Tinh_ID")
                        .HasColumnType("int");

                    b.Property<string>("Ghi_Chu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Loai_San_Pham_ID")
                        .HasColumnType("int");

                    b.Property<string>("Ma_San_Pham")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ten_San_Pham")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Auto_ID");

                    b.HasIndex("Don_Vi_Tinh_ID");

                    b.HasIndex("Loai_San_Pham_ID");

                    b.HasIndex("Ma_San_Pham")
                        .IsUnique();

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("web.Models.User", b =>
                {
                    b.Property<int>("Auto_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Auto_ID"));

                    b.Property<string>("Ghi_Chu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ho_Ten")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ma_Dang_Nhap")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mat_Khau")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Auto_ID");

                    b.HasIndex("Ma_Dang_Nhap")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("web.Models.XuatKho", b =>
                {
                    b.Property<int>("AutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoId"));

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KhoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayXuatKho")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoPhieuXuatKho")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AutoId");

                    b.HasIndex("KhoId");

                    b.HasIndex("SoPhieuXuatKho")
                        .IsUnique();

                    b.ToTable("XuatKhos");
                });

            modelBuilder.Entity("web.Models.XuatKhoRawData", b =>
                {
                    b.Property<int>("AutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutoId"));

                    b.Property<decimal>("DonGiaXuat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SLXuat")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("XuatKhoId")
                        .HasColumnType("int");

                    b.HasKey("AutoId");

                    b.HasIndex("SanPhamId");

                    b.HasIndex("XuatKhoId");

                    b.ToTable("XuatKhoRawDatas");
                });

            modelBuilder.Entity("web.Models.KhoUser", b =>
                {
                    b.HasOne("web.Models.Kho", "Kho")
                        .WithMany("KhoUsers")
                        .HasForeignKey("KhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web.Models.User", "User")
                        .WithMany("KhoUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kho");

                    b.Navigation("User");
                });

            modelBuilder.Entity("web.Models.NhapKho", b =>
                {
                    b.HasOne("web.Models.Kho", "Kho")
                        .WithMany("NhapKhos")
                        .HasForeignKey("KhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web.Models.NCC", "NCC")
                        .WithMany("NhapKhos")
                        .HasForeignKey("NCC_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kho");

                    b.Navigation("NCC");
                });

            modelBuilder.Entity("web.Models.NhapKhoRawData", b =>
                {
                    b.HasOne("web.Models.NhapKho", "NhapKho")
                        .WithMany("ChiTietNhapKhos")
                        .HasForeignKey("NhapKhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web.Models.SanPham", "SanPham")
                        .WithMany("ChiTietNhapKhos")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhapKho");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("web.Models.SanPham", b =>
                {
                    b.HasOne("web.Models.DonViTinh", "DonViTinh")
                        .WithMany("SanPhams")
                        .HasForeignKey("Don_Vi_Tinh_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web.Models.LoaiSanPham", "LoaiSanPham")
                        .WithMany("SanPhams")
                        .HasForeignKey("Loai_San_Pham_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonViTinh");

                    b.Navigation("LoaiSanPham");
                });

            modelBuilder.Entity("web.Models.XuatKho", b =>
                {
                    b.HasOne("web.Models.Kho", "Kho")
                        .WithMany("XuatKhos")
                        .HasForeignKey("KhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kho");
                });

            modelBuilder.Entity("web.Models.XuatKhoRawData", b =>
                {
                    b.HasOne("web.Models.SanPham", "SanPham")
                        .WithMany("ChiTietXuatKhos")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web.Models.XuatKho", "XuatKho")
                        .WithMany("ChiTietXuatKhos")
                        .HasForeignKey("XuatKhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");

                    b.Navigation("XuatKho");
                });

            modelBuilder.Entity("web.Models.DonViTinh", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("web.Models.Kho", b =>
                {
                    b.Navigation("KhoUsers");

                    b.Navigation("NhapKhos");

                    b.Navigation("XuatKhos");
                });

            modelBuilder.Entity("web.Models.LoaiSanPham", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("web.Models.NCC", b =>
                {
                    b.Navigation("NhapKhos");
                });

            modelBuilder.Entity("web.Models.NhapKho", b =>
                {
                    b.Navigation("ChiTietNhapKhos");
                });

            modelBuilder.Entity("web.Models.SanPham", b =>
                {
                    b.Navigation("ChiTietNhapKhos");

                    b.Navigation("ChiTietXuatKhos");
                });

            modelBuilder.Entity("web.Models.User", b =>
                {
                    b.Navigation("KhoUsers");
                });

            modelBuilder.Entity("web.Models.XuatKho", b =>
                {
                    b.Navigation("ChiTietXuatKhos");
                });
#pragma warning restore 612, 618
        }
    }
}
