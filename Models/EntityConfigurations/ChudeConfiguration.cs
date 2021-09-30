using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class ChudeConfiguration : IEntityTypeConfiguration<ChuDe>
    {
        public void Configure(EntityTypeBuilder<ChuDe> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.MaChuDe).IsUnique();

        }
    }
}
