﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLTV.AppMVC.Models;

namespace QLTV.AppMVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.BoMon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Khoa_Id")
                        .HasColumnType("int");

                    b.Property<string>("MaBoMon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenBoMon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Khoa_Id");

                    b.ToTable("BoMon");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.ChiTietMuon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HanTra")
                        .HasColumnType("datetime2");

                    b.Property<string>("MaSach")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayMuon")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTra")
                        .HasColumnType("datetime2");

                    b.Property<int>("PM_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaSach");

                    b.HasIndex("PM_Id");

                    b.ToTable("ChiTietMuon");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.ChuDe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaChuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenChuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaChuDe")
                        .IsUnique();

                    b.ToTable("ChuDe");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.DauSach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChuDe_Id")
                        .HasColumnType("int");

                    b.Property<string>("DinhKem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("GiaBia")
                        .HasColumnType("bigint");

                    b.Property<int?>("HocPhan_Id")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KeSach_Id")
                        .HasColumnType("int");

                    b.Property<string>("KhoCo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Khoa_Id")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiSach_Id")
                        .HasColumnType("int");

                    b.Property<string>("MaDauSach")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MinhHoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NXB_Id")
                        .HasColumnType("int");

                    b.Property<int?>("NamXB")
                        .HasColumnType("int");

                    b.Property<int?>("NgonNgu_Id")
                        .HasColumnType("int");

                    b.Property<string>("Nguon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhuChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SL")
                        .HasColumnType("int");

                    b.Property<int?>("SoTap")
                        .HasColumnType("int");

                    b.Property<int?>("SoTrang")
                        .HasColumnType("int");

                    b.Property<int?>("TacGia_Id")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaiBan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDauSach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKhac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TomTat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TungThu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChuDe_Id");

                    b.HasIndex("HocPhan_Id");

                    b.HasIndex("KeSach_Id");

                    b.HasIndex("Khoa_Id");

                    b.HasIndex("LoaiSach_Id");

                    b.HasIndex("MaDauSach")
                        .IsUnique();

                    b.HasIndex("NXB_Id");

                    b.HasIndex("NgonNgu_Id");

                    b.HasIndex("TacGia_Id");

                    b.ToTable("DauSach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.DieuKhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("NgayBD")
                        .HasColumnType("datetime2");

                    b.Property<int>("SLSach")
                        .HasColumnType("int");

                    b.Property<int>("ThoiHan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DieuKhoan");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.HocPhan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Khoa_Id")
                        .HasColumnType("int");

                    b.Property<string>("MaHocPhan")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TenHocPhan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Khoa_Id");

                    b.HasIndex("MaHocPhan")
                        .IsUnique()
                        .HasFilter("[MaHocPhan] IS NOT NULL");

                    b.ToTable("HocPhan");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.KeSach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenKeSach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KeSach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.Khoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaKhoa")
                        .IsUnique();

                    b.ToTable("Khoa");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.LoaiSach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaLoaiSach")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenLoaiSach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaLoaiSach")
                        .IsUnique();

                    b.ToTable("LoaiSach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.Lop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaLop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Nganh_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaLop")
                        .IsUnique()
                        .HasFilter("[MaLop] IS NOT NULL");

                    b.HasIndex("Nganh_Id");

                    b.ToTable("Lop");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.NXB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("TenNXB")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NXB");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.Nganh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoMon_Id")
                        .HasColumnType("int");

                    b.Property<string>("MaNganh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenNganh")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoMon_Id");

                    b.HasIndex("MaNganh")
                        .IsUnique()
                        .HasFilter("[MaNganh] IS NOT NULL");

                    b.ToTable("Nganh");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.NgonNgu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaNN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenNN")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("MaNN")
                        .IsUnique();

                    b.ToTable("NgonNgu");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.PhieuMuon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaSV")
                        .IsRequired()
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("MaSV")
                        .IsUnique();

                    b.ToTable("PhieuMuon");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.Sach", b =>
                {
                    b.Property<string>("MaSach")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("DangMuon")
                        .HasColumnType("bit");

                    b.Property<int>("DauSach_Id")
                        .HasColumnType("int");

                    b.HasKey("MaSach");

                    b.HasIndex("DauSach_Id");

                    b.ToTable("Sach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.SinhVien", b =>
                {
                    b.Property<string>("MaSV")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("Lop_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("TenSV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSV");

                    b.HasIndex("Lop_Id");

                    b.ToTable("SinhVien");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.TacGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTG")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phone")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id");

                    b.ToTable("TacGia");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLTV.AppMVC.Models.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.BoMon", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.Khoa", "Khoa")
                        .WithMany("Ds_BoMon")
                        .HasForeignKey("Khoa_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.ChiTietMuon", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.Sach", "Sach")
                        .WithMany()
                        .HasForeignKey("MaSach")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("QLTV.AppMVC.Models.Entities.PhieuMuon", "PhieuMuon")
                        .WithMany("DS_CTM")
                        .HasForeignKey("PM_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuMuon");

                    b.Navigation("Sach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.DauSach", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.ChuDe", "ChuDe")
                        .WithMany("DS_DauSach")
                        .HasForeignKey("ChuDe_Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("QLTV.AppMVC.Models.Entities.HocPhan", "HocPhan")
                        .WithMany("DS_DauSach")
                        .HasForeignKey("HocPhan_Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("QLTV.AppMVC.Models.Entities.KeSach", "KeSach")
                        .WithMany("DS_DauSach")
                        .HasForeignKey("KeSach_Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("QLTV.AppMVC.Models.Entities.Khoa", "Khoa")
                        .WithMany("DS_DauSach")
                        .HasForeignKey("Khoa_Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("QLTV.AppMVC.Models.Entities.LoaiSach", "LoaiSach")
                        .WithMany("DS_DauSach")
                        .HasForeignKey("LoaiSach_Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("QLTV.AppMVC.Models.Entities.NXB", "NXB")
                        .WithMany("DS_DauSach")
                        .HasForeignKey("NXB_Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("QLTV.AppMVC.Models.Entities.NgonNgu", "NgonNgu")
                        .WithMany()
                        .HasForeignKey("NgonNgu_Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("QLTV.AppMVC.Models.Entities.TacGia", "TacGia")
                        .WithMany("DS_DauSach")
                        .HasForeignKey("TacGia_Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ChuDe");

                    b.Navigation("HocPhan");

                    b.Navigation("KeSach");

                    b.Navigation("Khoa");

                    b.Navigation("LoaiSach");

                    b.Navigation("NgonNgu");

                    b.Navigation("NXB");

                    b.Navigation("TacGia");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.HocPhan", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.Khoa", "Khoa")
                        .WithMany()
                        .HasForeignKey("Khoa_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.Lop", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.Nganh", "Nganh")
                        .WithMany("Ds_Lop")
                        .HasForeignKey("Nganh_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nganh");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.Nganh", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.BoMon", "BoMon")
                        .WithMany("Ds_Nganh")
                        .HasForeignKey("BoMon_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoMon");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.PhieuMuon", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.SinhVien", "SinhVien")
                        .WithOne("PhieuMuon")
                        .HasForeignKey("QLTV.AppMVC.Models.Entities.PhieuMuon", "MaSV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.Sach", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.DauSach", "DauSach")
                        .WithMany()
                        .HasForeignKey("DauSach_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DauSach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.SinhVien", b =>
                {
                    b.HasOne("QLTV.AppMVC.Models.Entities.Lop", "Lop")
                        .WithMany("DS_SinhVien")
                        .HasForeignKey("Lop_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Lop");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.BoMon", b =>
                {
                    b.Navigation("Ds_Nganh");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.ChuDe", b =>
                {
                    b.Navigation("DS_DauSach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.HocPhan", b =>
                {
                    b.Navigation("DS_DauSach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.KeSach", b =>
                {
                    b.Navigation("DS_DauSach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.Khoa", b =>
                {
                    b.Navigation("Ds_BoMon");

                    b.Navigation("DS_DauSach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.LoaiSach", b =>
                {
                    b.Navigation("DS_DauSach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.Lop", b =>
                {
                    b.Navigation("DS_SinhVien");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.NXB", b =>
                {
                    b.Navigation("DS_DauSach");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.Nganh", b =>
                {
                    b.Navigation("Ds_Lop");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.PhieuMuon", b =>
                {
                    b.Navigation("DS_CTM");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.SinhVien", b =>
                {
                    b.Navigation("PhieuMuon");
                });

            modelBuilder.Entity("QLTV.AppMVC.Models.Entities.TacGia", b =>
                {
                    b.Navigation("DS_DauSach");
                });
#pragma warning restore 612, 618
        }
    }
}
