using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class LoaiSachConfiguration : IEntityTypeConfiguration<LoaiSach>
    {
        public void Configure(EntityTypeBuilder<LoaiSach> builder)
        {
            builder.HasKey(ls => ls.Id);

            builder.HasIndex(ls => ls.MaLoaiSach).IsUnique();
        }
    }
}
