using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class Khoa
    {
        public int Id { get; set; }

        [DisplayName("Mã khoa"),Required(ErrorMessage ="Phải nhập {0}")]
        public string MaKhoa { get; set; }

        [DisplayName("Tên khoa"),Required(ErrorMessage ="Phải nhập {0}")]
        public string TenKhoa { get; set; }
        public List<BoMon> Ds_BoMon { get; set; }
        public List<DauSach> DS_DauSach { get; set; }

    }
}
