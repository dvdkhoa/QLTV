using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class DauSachConfiguration : IEntityTypeConfiguration<DauSach>
    {
        public void Configure(EntityTypeBuilder<DauSach> builder)
        {
            builder.HasKey(ds => ds.Id);

            builder.HasIndex(ds => ds.MaDauSach).IsUnique();

            builder.HasOne(ds => ds.LoaiSach)
                    .WithMany(ls => ls.DS_DauSach)
                    .HasForeignKey(ds => ds.LoaiSach_Id)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ds => ds.ChuDe)
                    .WithMany(cd => cd.DS_DauSach)
                    .HasForeignKey(ds => ds.ChuDe_Id)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ds => ds.TacGia)
                    .WithMany(tg => tg.DS_DauSach)
                    .HasForeignKey(ds => ds.TacGia_Id)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ds => ds.NXB)
                    .WithMany(nxb => nxb.DS_DauSach)
                    .HasForeignKey(ds => ds.NXB_Id)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ds => ds.Khoa)
                    .WithMany(k => k.DS_DauSach)
                    .HasForeignKey(ds => ds.Khoa_Id)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ds => ds.HocPhan)
                    .WithMany(hp => hp.DS_DauSach)
                    .HasForeignKey(ds => ds.HocPhan_Id)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ds => ds.KeSach)
                    .WithMany(hp => hp.DS_DauSach)
                    .HasForeignKey(ds => ds.KeSach_Id)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ds => ds.NgonNgu)
                    .WithMany()
                    .HasForeignKey(ds => ds.NgonNgu_Id)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(ds => ds.GiaBia).IsRequired(false);
        }
    }
}
