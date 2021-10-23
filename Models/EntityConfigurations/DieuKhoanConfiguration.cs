using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.EntityConfigurations
{
    public class DieuKhoanConfiguration : IEntityTypeConfiguration<DieuKhoan>
    {
        public void Configure(EntityTypeBuilder<DieuKhoan> builder)
        {
            
        }
    }
}
