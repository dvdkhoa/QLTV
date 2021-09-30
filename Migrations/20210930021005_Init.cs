using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLTV.AppMVC.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChuDe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaChuDe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenChuDe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeSach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKeSach = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeSach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoaiSach = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiSach = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NgonNgu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgonNgu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NXB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNXB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NXB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TacGia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoMon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBoMon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenBoMon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Khoa_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoMon_Khoa_Khoa_Id",
                        column: x => x.Khoa_Id,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HocPhan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHocPhan = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    TenHocPhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Khoa_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocPhan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HocPhan_Khoa_Khoa_Id",
                        column: x => x.Khoa_Id,
                        principalTable: "Khoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nganh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNganh = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenNganh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoMon_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nganh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nganh_BoMon_BoMon_Id",
                        column: x => x.BoMon_Id,
                        principalTable: "BoMon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DauSach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDauSach = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDauSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SL = table.Column<int>(type: "int", nullable: false),
                    LoaiSach_Id = table.Column<int>(type: "int", nullable: true),
                    ChuDe_Id = table.Column<int>(type: "int", nullable: true),
                    TacGia_Id = table.Column<int>(type: "int", nullable: true),
                    NXB_Id = table.Column<int>(type: "int", nullable: true),
                    NamXB = table.Column<int>(type: "int", nullable: true),
                    Khoa_Id = table.Column<int>(type: "int", nullable: true),
                    HocPhan_Id = table.Column<int>(type: "int", nullable: true),
                    KeSach_Id = table.Column<int>(type: "int", nullable: true),
                    SoTrang = table.Column<int>(type: "int", nullable: true),
                    KhoCo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinhHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaBia = table.Column<long>(type: "bigint", nullable: true),
                    Nguon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenKhac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TungThu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTap = table.Column<int>(type: "int", nullable: true),
                    TenTap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DinhKem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgonNgu_Id = table.Column<int>(type: "int", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DauSach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DauSach_ChuDe_ChuDe_Id",
                        column: x => x.ChuDe_Id,
                        principalTable: "ChuDe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DauSach_HocPhan_HocPhan_Id",
                        column: x => x.HocPhan_Id,
                        principalTable: "HocPhan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DauSach_KeSach_KeSach_Id",
                        column: x => x.KeSach_Id,
                        principalTable: "KeSach",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DauSach_Khoa_Khoa_Id",
                        column: x => x.Khoa_Id,
                        principalTable: "Khoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DauSach_LoaiSach_LoaiSach_Id",
                        column: x => x.LoaiSach_Id,
                        principalTable: "LoaiSach",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DauSach_NgonNgu_NgonNgu_Id",
                        column: x => x.NgonNgu_Id,
                        principalTable: "NgonNgu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DauSach_NXB_NXB_Id",
                        column: x => x.NXB_Id,
                        principalTable: "NXB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DauSach_TacGia_TacGia_Id",
                        column: x => x.TacGia_Id,
                        principalTable: "TacGia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLop = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nganh_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lop_Nganh_Nganh_Id",
                        column: x => x.Nganh_Id,
                        principalTable: "Nganh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DauSach_Id = table.Column<int>(type: "int", nullable: false),
                    DangMuon = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sach_DauSach_DauSach_Id",
                        column: x => x.DauSach_Id,
                        principalTable: "DauSach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSV = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    TenSV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    Lop_Id = table.Column<int>(type: "int", nullable: false),
                    Nganh_Id = table.Column<int>(type: "int", nullable: false),
                    Khoa_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinhVien_Khoa_Khoa_Id",
                        column: x => x.Khoa_Id,
                        principalTable: "Khoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_Lop_Lop_Id",
                        column: x => x.Lop_Id,
                        principalTable: "Lop",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SinhVien_Nganh_Nganh_Id",
                        column: x => x.Nganh_Id,
                        principalTable: "Nganh",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhieuMuon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinhVien_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuMuon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuMuon_SinhVien_SinhVien_Id",
                        column: x => x.SinhVien_Id,
                        principalTable: "SinhVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietMuon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PM_Id = table.Column<int>(type: "int", nullable: false),
                    Sach_Id = table.Column<int>(type: "int", nullable: false),
                    NgayMuon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietMuon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietMuon_PhieuMuon_PM_Id",
                        column: x => x.PM_Id,
                        principalTable: "PhieuMuon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietMuon_Sach_Sach_Id",
                        column: x => x.Sach_Id,
                        principalTable: "Sach",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoMon_Khoa_Id",
                table: "BoMon",
                column: "Khoa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuon_PM_Id",
                table: "ChiTietMuon",
                column: "PM_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuon_Sach_Id",
                table: "ChiTietMuon",
                column: "Sach_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChuDe_MaChuDe",
                table: "ChuDe",
                column: "MaChuDe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DauSach_ChuDe_Id",
                table: "DauSach",
                column: "ChuDe_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DauSach_HocPhan_Id",
                table: "DauSach",
                column: "HocPhan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DauSach_KeSach_Id",
                table: "DauSach",
                column: "KeSach_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DauSach_Khoa_Id",
                table: "DauSach",
                column: "Khoa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DauSach_LoaiSach_Id",
                table: "DauSach",
                column: "LoaiSach_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DauSach_MaDauSach",
                table: "DauSach",
                column: "MaDauSach",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DauSach_NgonNgu_Id",
                table: "DauSach",
                column: "NgonNgu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DauSach_NXB_Id",
                table: "DauSach",
                column: "NXB_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DauSach_TacGia_Id",
                table: "DauSach",
                column: "TacGia_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HocPhan_Khoa_Id",
                table: "HocPhan",
                column: "Khoa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HocPhan_MaHocPhan",
                table: "HocPhan",
                column: "MaHocPhan",
                unique: true,
                filter: "[MaHocPhan] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_MaKhoa",
                table: "Khoa",
                column: "MaKhoa",
                unique: true,
                filter: "[MaKhoa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSach_MaLoaiSach",
                table: "LoaiSach",
                column: "MaLoaiSach",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lop_MaLop",
                table: "Lop",
                column: "MaLop",
                unique: true,
                filter: "[MaLop] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lop_Nganh_Id",
                table: "Lop",
                column: "Nganh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Nganh_BoMon_Id",
                table: "Nganh",
                column: "BoMon_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Nganh_MaNganh",
                table: "Nganh",
                column: "MaNganh",
                unique: true,
                filter: "[MaNganh] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NgonNgu_MaNN",
                table: "NgonNgu",
                column: "MaNN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuon_SinhVien_Id",
                table: "PhieuMuon",
                column: "SinhVien_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_DauSach_Id",
                table: "Sach",
                column: "DauSach_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_Khoa_Id",
                table: "SinhVien",
                column: "Khoa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_Lop_Id",
                table: "SinhVien",
                column: "Lop_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaSV",
                table: "SinhVien",
                column: "MaSV",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_Nganh_Id",
                table: "SinhVien",
                column: "Nganh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietMuon");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "PhieuMuon");

            migrationBuilder.DropTable(
                name: "Sach");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "DauSach");

            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "ChuDe");

            migrationBuilder.DropTable(
                name: "HocPhan");

            migrationBuilder.DropTable(
                name: "KeSach");

            migrationBuilder.DropTable(
                name: "LoaiSach");

            migrationBuilder.DropTable(
                name: "NgonNgu");

            migrationBuilder.DropTable(
                name: "NXB");

            migrationBuilder.DropTable(
                name: "TacGia");

            migrationBuilder.DropTable(
                name: "Nganh");

            migrationBuilder.DropTable(
                name: "BoMon");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
