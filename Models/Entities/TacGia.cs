using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class TacGia
    {
        public int Id { get; set; }

        [DisplayName("Tên tác giả")]
        [Required(ErrorMessage ="Không được bỏ trống {0}")]
        public string TenTG { get; set; }

        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [DisplayName("Số điện thoại")]
        public string phone { get; set; }
        public List<DauSach> DS_DauSach { get; set; }
    }
}
