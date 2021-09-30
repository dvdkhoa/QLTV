using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class NXBConfiguration : IEntityTypeConfiguration<NXB>
    {
        public void Configure(EntityTypeBuilder<NXB> builder)
        {
            builder.HasKey(nxb => nxb.Id);

            builder.Property(nxb => nxb.Phone).HasColumnType("varchar").HasMaxLength(12);
        }
    }
}
