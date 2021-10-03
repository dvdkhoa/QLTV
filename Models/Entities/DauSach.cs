using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class DauSach
    {
        public int Id { get; set; }


        [Display(Name ="Mã đầu sách")]
        [Required(ErrorMessage ="Phải nhập {0}")]
        public string MaDauSach { get; set; }


        [Display(Name = "Tên đầu sách")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string TenDauSach { get; set; }


        public string ImagePath { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }


        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public int SL { get; set; }


        [Display(Name ="Loại sách")]
        public int? LoaiSach_Id { get; set; }
        public LoaiSach LoaiSach { get; set; }


        [Display(Name = "Chủ đề")]
        public int? ChuDe_Id { get; set; }
        public ChuDe ChuDe { get; set; }


        [Display(Name = "Tác giả")]
        public int? TacGia_Id { get; set; }
        public TacGia TacGia { get; set; }


        [Display(Name = "NXB")]
        public int? NXB_Id { get; set; }
        public NXB NXB { get; set; }


        [Display(Name ="Năm xuất bản")]
        public int? NamXB { get; set; }


        [Display(Name = "Khoa")]
        public int? Khoa_Id { get; set; }
        public Khoa Khoa { get; set; }


        [Display(Name = "Học phần")]
        public int? HocPhan_Id { get; set; }
        public HocPhan HocPhan { get; set; }


        [Display(Name ="Kệ sách")]
        public int? KeSach_Id { get; set; }
        public KeSach KeSach { get; set; }


        [Display(Name ="Số trang")]
        public int? SoTrang { get; set; }


        [Display(Name ="Khổ cỡ")]
        public string KhoCo { get; set; }


        [Display(Name ="Từ khóa( dùng để tìm kiếm )")]
        public string Tags { get; set; }


        [Display(Name ="Minh họa")]
        public string MinhHoa { get; set; }


        [Display(Name ="Giá bìa")]
        public long? GiaBia { get; set; }


        [Display(Name ="Nguồn")]
        public string Nguon { get; set; }


        [Display(Name = "Tên khác")]
        public string TenKhac { get; set; }


        [Display(Name = "Tùng thư")]
        public string TungThu { get; set; }


        [Display(Name ="Số tập")]
        public int? SoTap { get; set; }


        [Display(Name ="Tên tập")]
        public string TenTap { get; set; }


        [Display(Name = "Đính kèm")]
        public string DinhKem { get; set; }


        [Display(Name ="Ngôn ngữ")]
        public int? NgonNgu_Id { get; set; }
        public NgonNgu NgonNgu { get; set; }

        
        public string ISBN { get; set; }

    }
}
