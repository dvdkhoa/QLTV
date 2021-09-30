using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class SachConfiguration : IEntityTypeConfiguration<Sach>
    {
        public void Configure(EntityTypeBuilder<Sach> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.DauSach)
                    .WithMany()
                    .HasForeignKey(s => s.DauSach_Id)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
