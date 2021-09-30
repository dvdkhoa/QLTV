using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class NgonNgu
    {
        public int Id { get; set; }

        [Display(Name = "Mã ngôn ngữ")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string MaNN { get; set; }

        [Display(Name = "Tên ngôn ngữ")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string TenNN { get; set; }
    }
}
