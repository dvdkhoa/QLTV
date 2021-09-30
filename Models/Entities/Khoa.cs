using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class Khoa
    {
        public int Id { get; set; }

        [DisplayName("Mã khoa")]
        public string MaKhoa { get; set; }

        [DisplayName("Tên khoa")]
        public string TenKhoa { get; set; }
        public List<BoMon> Ds_BoMon { get; set; }
        public List<DauSach> DS_DauSach { get; set; }

    }
}
