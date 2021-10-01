using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class PhieuMuonConfiguration : IEntityTypeConfiguration<PhieuMuon>
    {
        public void Configure(EntityTypeBuilder<PhieuMuon> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.HasOne(pm => pm.SinhVien)
                    .WithOne(sv=>sv.PhieuMuon)
                    .HasForeignKey<PhieuMuon>(pm => pm.MaSV);
        }
    }
}
