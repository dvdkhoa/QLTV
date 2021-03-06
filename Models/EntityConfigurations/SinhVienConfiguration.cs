using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class SinhVienConfiguration : IEntityTypeConfiguration<SinhVien>
    {
        public void Configure(EntityTypeBuilder<SinhVien> builder)
        {
            builder.HasKey(sv => sv.MaSV);
            builder.Property(sv => sv.MaSV).HasColumnType("varchar")
                                            .HasMaxLength(12)
                                            .IsRequired();

            builder.Property(sv => sv.Phone).HasColumnType("varchar").HasMaxLength(12);


            builder.Property(sv => sv.GioiTinh)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(5).IsRequired(true);

            builder.HasOne(sv => sv.Lop)
                    .WithMany(lop => lop.DS_SinhVien)
                    .HasForeignKey(sv => sv.Lop_Id)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(sv => sv.NgaySinh).HasColumnType("date");
        }
    }
}
