using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class Lop
    {
        public int Id { get; set; }

        [DisplayName("Mã lớp")]
        public string MaLop { get; set; }
        public List<SinhVien> DS_SinhVien { get; set; }

        [DisplayName("Ngành")]
        public int Nganh_Id { get; set; }
        public Nganh Nganh { get; set; }
    }
}
