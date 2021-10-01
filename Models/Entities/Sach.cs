using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class Sach
    {
        [Display(Name ="Mã sách")]
        public string MaSach { get; set; }
        public int DauSach_Id { get; set; }
        public DauSach DauSach { get; set; }


        [Display(Name ="Trạng thái")]
        public bool DangMuon { get; set; }
    }
}
