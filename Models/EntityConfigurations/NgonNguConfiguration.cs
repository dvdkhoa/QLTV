using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class NgonNguConfiguration : IEntityTypeConfiguration<NgonNgu>
    {
        public void Configure(EntityTypeBuilder<NgonNgu> builder)
        {
            builder.HasKey(n => n.Id);

            builder.HasIndex(n => n.MaNN).IsUnique();

            builder.Property(n => n.TenNN)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(30);
        }
    }
}
