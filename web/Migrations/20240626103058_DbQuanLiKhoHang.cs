using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    /// <inheritdoc />
    public partial class DbQuanLiKhoHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonViTinhs",
                columns: table => new
                {
                    Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Don_Vi_Tinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViTinhs", x => x.Auto_ID);
                });

            migrationBuilder.CreateTable(
                name: "Khos",
                columns: table => new
                {
                    Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Kho = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khos", x => x.Auto_ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_LSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ten_LSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.Auto_ID);
                });

            migrationBuilder.CreateTable(
                name: "NCCs",
                columns: table => new
                {
                    Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_NCC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ten_NCC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCCs", x => x.Auto_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_Dang_Nhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mat_Khau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ho_Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Auto_ID);
                });

            migrationBuilder.CreateTable(
                name: "XuatKhos",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhieuXuatKho = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KhoId = table.Column<int>(type: "int", nullable: false),
                    NgayXuatKho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XuatKhos", x => x.AutoId);
                    table.ForeignKey(
                        name: "FK_XuatKhos_Khos_KhoId",
                        column: x => x.KhoId,
                        principalTable: "Khos",
                        principalColumn: "Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Auto_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_San_Pham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ten_San_Pham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Loai_San_Pham_ID = table.Column<int>(type: "int", nullable: false),
                    Don_Vi_Tinh_ID = table.Column<int>(type: "int", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Auto_ID);
                    table.ForeignKey(
                        name: "FK_SanPhams_DonViTinhs_Don_Vi_Tinh_ID",
                        column: x => x.Don_Vi_Tinh_ID,
                        principalTable: "DonViTinhs",
                        principalColumn: "Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSanPhams_Loai_San_Pham_ID",
                        column: x => x.Loai_San_Pham_ID,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhapKhos",
                columns: table => new
                {
                    Auto_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhieuNhapKho = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KhoId = table.Column<int>(type: "int", nullable: false),
                    NCC_Id = table.Column<int>(type: "int", nullable: false),
                    NgayNhapKho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapKhos", x => x.Auto_Id);
                    table.ForeignKey(
                        name: "FK_NhapKhos_Khos_KhoId",
                        column: x => x.KhoId,
                        principalTable: "Khos",
                        principalColumn: "Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhapKhos_NCCs_NCC_Id",
                        column: x => x.NCC_Id,
                        principalTable: "NCCs",
                        principalColumn: "Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhoUsers",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    KhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoUsers", x => x.AutoId);
                    table.ForeignKey(
                        name: "FK_KhoUsers_Khos_KhoId",
                        column: x => x.KhoId,
                        principalTable: "Khos",
                        principalColumn: "Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhoUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XuatKhoRawDatas",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XuatKhoId = table.Column<int>(type: "int", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    SLXuat = table.Column<int>(type: "int", nullable: false),
                    DonGiaXuat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XuatKhoRawDatas", x => x.AutoId);
                    table.ForeignKey(
                        name: "FK_XuatKhoRawDatas_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XuatKhoRawDatas_XuatKhos_XuatKhoId",
                        column: x => x.XuatKhoId,
                        principalTable: "XuatKhos",
                        principalColumn: "AutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhapKhoRawDatas",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhapKhoId = table.Column<int>(type: "int", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    SLNhap = table.Column<int>(type: "int", nullable: false),
                    DonGiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapKhoRawDatas", x => x.AutoId);
                    table.ForeignKey(
                        name: "FK_NhapKhoRawDatas_NhapKhos_NhapKhoId",
                        column: x => x.NhapKhoId,
                        principalTable: "NhapKhos",
                        principalColumn: "Auto_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhapKhoRawDatas_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Auto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonViTinhs_Ten_Don_Vi_Tinh",
                table: "DonViTinhs",
                column: "Ten_Don_Vi_Tinh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Khos_Ten_Kho",
                table: "Khos",
                column: "Ten_Kho",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhoUsers_KhoId",
                table: "KhoUsers",
                column: "KhoId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoUsers_UserId_KhoId",
                table: "KhoUsers",
                columns: new[] { "UserId", "KhoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPhams_Ma_LSP",
                table: "LoaiSanPhams",
                column: "Ma_LSP",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPhams_Ten_LSP",
                table: "LoaiSanPhams",
                column: "Ten_LSP",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NCCs_Ten_NCC",
                table: "NCCs",
                column: "Ten_NCC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhoRawDatas_NhapKhoId",
                table: "NhapKhoRawDatas",
                column: "NhapKhoId");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhoRawDatas_SanPhamId",
                table: "NhapKhoRawDatas",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhos_KhoId",
                table: "NhapKhos",
                column: "KhoId");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhos_NCC_Id",
                table: "NhapKhos",
                column: "NCC_Id");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhos_SoPhieuNhapKho",
                table: "NhapKhos",
                column: "SoPhieuNhapKho",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Don_Vi_Tinh_ID",
                table: "SanPhams",
                column: "Don_Vi_Tinh_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Loai_San_Pham_ID",
                table: "SanPhams",
                column: "Loai_San_Pham_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Ma_San_Pham",
                table: "SanPhams",
                column: "Ma_San_Pham",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Ma_Dang_Nhap",
                table: "Users",
                column: "Ma_Dang_Nhap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_XuatKhoRawDatas_SanPhamId",
                table: "XuatKhoRawDatas",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_XuatKhoRawDatas_XuatKhoId",
                table: "XuatKhoRawDatas",
                column: "XuatKhoId");

            migrationBuilder.CreateIndex(
                name: "IX_XuatKhos_KhoId",
                table: "XuatKhos",
                column: "KhoId");

            migrationBuilder.CreateIndex(
                name: "IX_XuatKhos_SoPhieuXuatKho",
                table: "XuatKhos",
                column: "SoPhieuXuatKho",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhoUsers");

            migrationBuilder.DropTable(
                name: "NhapKhoRawDatas");

            migrationBuilder.DropTable(
                name: "XuatKhoRawDatas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "NhapKhos");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "XuatKhos");

            migrationBuilder.DropTable(
                name: "NCCs");

            migrationBuilder.DropTable(
                name: "DonViTinhs");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");

            migrationBuilder.DropTable(
                name: "Khos");
        }
    }
}
