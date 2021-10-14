using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class DieuKhoan
    {
        public int Id { get; set; }
        public int SLSach { get; set; }
        public int ThoiHan { get; set; }
        public DateTime NgayBD { get; set; }
    }
}
