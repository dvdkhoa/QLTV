using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class SinhVien
    {

        [DisplayName("Mã sinh viên")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string MaSV { get; set; }

        [DisplayName("Tên sinh viên")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string TenSV { get; set; }

        [Display(Name ="Email"),DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Phải nhập {0}")]
        public string Email { get; set; }

        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string GioiTinh { get; set; }

        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }
        [DisplayName("Lớp")]
        public int Lop_Id { get; set; }
        public Lop Lop { get; set; }

        public PhieuMuon PhieuMuon { get; set; }
    }
}
