using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class NganhConfiguration : IEntityTypeConfiguration<Nganh>
    {
        public void Configure(EntityTypeBuilder<Nganh> builder)
        {
            builder.HasKey(nganh => nganh.Id);
            builder.HasIndex(nganh => nganh.MaNganh).IsUnique();
            builder.HasOne(nganh => nganh.BoMon)
                .WithMany(boMon => boMon.Ds_Nganh)
                .HasForeignKey(nganh => nganh.BoMon_Id);
        }
    }
}
