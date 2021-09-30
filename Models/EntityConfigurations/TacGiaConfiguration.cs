using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class TacGiaConfiguration : IEntityTypeConfiguration<TacGia>
    {
        public void Configure(EntityTypeBuilder<TacGia> builder)
        {
            builder.HasKey(tg => tg.Id);

            builder.Property(tg => tg.TenTG).HasMaxLength(50);

            builder.Property(tg => tg.phone).HasColumnType("varchar").HasMaxLength(12);
        }
    }
}
