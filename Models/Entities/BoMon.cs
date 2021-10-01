using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class BoMon
    {
        public int Id { get; set; }

        [DisplayName("Mã bộ môn"),Required(ErrorMessage ="Phải nhập {0}")]
        public string MaBoMon { get; set; }

        [DisplayName("Tên bộ môn"), Required(ErrorMessage = "Phải nhập {0}")]
        public string TenBoMon { get; set; }
        
        [DisplayName("Khoa")]
        public int Khoa_Id { get; set; }

        public Khoa Khoa { get; set; }
        public List<Nganh> Ds_Nganh { get; set; }

    }
}
