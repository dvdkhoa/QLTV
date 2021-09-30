using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class HocPhanConfiguration : IEntityTypeConfiguration<HocPhan>
    {
        public void Configure(EntityTypeBuilder<HocPhan> builder)
        {
            builder.HasKey(hp => hp.Id);

            builder.HasIndex(hp => hp.MaHocPhan).IsUnique();

            builder.HasOne(hp => hp.Khoa)
                    .WithMany()
                    .HasForeignKey(hp => hp.Khoa_Id);

            builder.Property(hp => hp.MaHocPhan).HasColumnType("varchar").HasMaxLength(20);
        }
    }
}
