using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class NXB
    {
        public int Id { get; set; }

        [DisplayName("Tên NXB")]
        public string TenNXB { get; set; }

        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }
        public List<DauSach> DS_DauSach { get; set; }

    }
}
