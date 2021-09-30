using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class PhieuMuon
    {
        [Display(Name ="Mã phiếu")]
        public int Id { get; set; }

        [Display(Name ="Sinh viên")]
        [Required(ErrorMessage ="Phải nhập {0}")]
        public int SinhVien_Id { get; set; }
        public SinhVien SinhVien { get; set; }

        public List<ChiTietMuon> DS_CTM { get; set; }
  
    }
}
