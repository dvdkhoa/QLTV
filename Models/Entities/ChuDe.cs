using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class ChuDe
    {
        public int Id { get; set; }

        [Display(Name ="Mã chủ đề")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string MaChuDe { get; set; }

        [Display(Name = "Tên chủ đề")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string TenChuDe { get; set; }

        public List<DauSach> DS_DauSach { get; set; }

    }
}
