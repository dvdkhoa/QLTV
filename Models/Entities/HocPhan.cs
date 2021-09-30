using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class HocPhan
    {
        public int Id { get; set; }

        [DisplayName("Mã học phần")]
        public string MaHocPhan { get; set; }

        [DisplayName("Tên học phần")]
        public string TenHocPhan { get; set; }

        [DisplayName("Khoa")]
        public int Khoa_Id { get; set; }
        public Khoa Khoa { get; set; }
        public List<DauSach> DS_DauSach { get; set; }
    }
}
