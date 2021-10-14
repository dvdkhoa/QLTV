
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLTV.AppMVC.Models.Entities;
using QLTV.AppMVC.Models.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext( DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình Entities
            modelBuilder.ApplyConfiguration(new BoMonConfiguration());
            modelBuilder.ApplyConfiguration(new KhoaConfiguration());
            modelBuilder.ApplyConfiguration(new NganhConfiguration());
            modelBuilder.ApplyConfiguration(new HocPhanConfiguration());
            modelBuilder.ApplyConfiguration(new LopConfiguration());
            modelBuilder.ApplyConfiguration(new SinhVienConfiguration());
            modelBuilder.ApplyConfiguration(new PhieuMuonConfiguration());
            modelBuilder.ApplyConfiguration(new CTMuonConfiguration());
            modelBuilder.ApplyConfiguration(new SachConfiguration());
            modelBuilder.ApplyConfiguration(new DauSachConfiguration());
            modelBuilder.ApplyConfiguration(new KeSachConfiguration());
            modelBuilder.ApplyConfiguration(new TacGiaConfiguration());
            modelBuilder.ApplyConfiguration(new NXBConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiSachConfiguration());
            modelBuilder.ApplyConfiguration(new ChudeConfiguration());
            modelBuilder.ApplyConfiguration(new NgonNguConfiguration());
            modelBuilder.ApplyConfiguration(new DieuKhoanConfiguration());

            // Cấu hình các bảng Identity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    var newName = tableName.Substring(6);

                    entityType.SetTableName(newName);
                }
            }

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<BoMon> BoMon { get; set; }
        public DbSet<ChiTietMuon> ChiTietMuon  { get; set; }
        public DbSet<ChuDe> ChuDe { get; set; }
        public DbSet<DauSach> DauSach { get; set; }
        public DbSet<HocPhan> HocPhan { get; set; }
        public DbSet<KeSach> KeSach { get; set; }
        public DbSet<Khoa> Khoa { get; set; }
        public DbSet<LoaiSach> LoaiSach { get; set; }
        public DbSet<Nganh> Nganh { get; set; }
        public DbSet<NXB> NXB { get; set; }
        public DbSet<PhieuMuon> PhieuMuon { get; set; }
        public DbSet<Sach> Sach { get; set; }
        public DbSet<SinhVien> SinhVien { get; set; }
        public DbSet<TacGia> TacGia { get; set; }
        public DbSet<Lop> Lop { get; set; }
        public DbSet<NgonNgu> NgonNgu { get; set; }
        public DbSet<DieuKhoan> DieuKhoan { get; set; }
    }
}
