using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    class KhoaConfiguration : IEntityTypeConfiguration<Khoa>
    {
        public void Configure(EntityTypeBuilder<Khoa> builder)
        {
            builder.HasKey(khoa => khoa.Id);
            builder.HasIndex(khoa => khoa.MaKhoa).IsUnique();
        }
    }
}
