using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class LopConfiguration : IEntityTypeConfiguration<Lop>
    {
        public void Configure(EntityTypeBuilder<Lop> builder)
        {
            builder.HasKey(lop => lop.Id);

            builder.HasIndex(lop => lop.MaLop).IsUnique();

            builder.HasOne(lop => lop.Nganh)
                .WithMany(nganh => nganh.Ds_Lop)
                .HasForeignKey(lop => lop.Nganh_Id);
        }
    }
}
