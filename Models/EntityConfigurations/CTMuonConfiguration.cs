using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class CTMuonConfiguration : IEntityTypeConfiguration<ChiTietMuon>
    {
        public void Configure(EntityTypeBuilder<ChiTietMuon> builder)
        {
            builder.HasKey(ctm => ctm.Id);

            builder.HasOne(ctm => ctm.PhieuMuon)
                    .WithMany(pm => pm.DS_CTM)
                    .HasForeignKey(ctm => ctm.PM_Id);

            builder.HasOne(ctm => ctm.Sach)
                    .WithMany()
                    .HasForeignKey(ctm => ctm.MaSach)
                    .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Property(ctm => ctm.NgayMuon).IsRequired();
            
            builder.Property(ctm => ctm.NgayTra).IsRequired(false);

        }
    }
}
