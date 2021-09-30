using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace QLTV.AppMVC.Models.Entities
{
    public class LoaiSach
    {
        public int Id { get; set; }

        [Display(Name ="Mã loại sách")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string MaLoaiSach { get; set; }

        [Display(Name = "Tên loại sách")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string TenLoaiSach { get; set; }

        public List<DauSach> DS_DauSach { get; set; }
    }
}
