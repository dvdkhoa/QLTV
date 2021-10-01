
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class ChiTietMuon
    {
        public int Id { get; set; }
        public int PM_Id { get; set; }
        public PhieuMuon PhieuMuon { get; set; }

        [Display(Name ="Mã sách"),Required(ErrorMessage ="Phải nhập {0}")]
        public string MaSach { get; set; }
        public Sach Sach { get; set; }
        
        [Display(Name ="Ngày mượn"),DataType(DataType.Date)]
        [Required(ErrorMessage ="Không được bỏ trống {0}")]
        public DateTime NgayMuon { get; set; }

        [Display(Name = "Ngày trả"), DataType(DataType.Date)]
        public DateTime? NgayTra { get; set; }
    }
}
