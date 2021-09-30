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
    class BoMonConfiguration : IEntityTypeConfiguration<BoMon>
    {
        public void Configure(EntityTypeBuilder<BoMon> builder)
        {
            builder.HasKey(boMon => boMon.Id);
            builder.Property(boMon => boMon.MaBoMon).IsRequired();
            builder.HasOne(boMon => boMon.Khoa)
                .WithMany(khoa => khoa.Ds_BoMon)
                .HasForeignKey(boMon => boMon.Khoa_Id);
        }
    }
}
