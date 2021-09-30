using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class KeSach
    {
        public int Id { get; set; }

        [DisplayName("Tên kệ sách")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string TenKeSach { get; set; }

        public List<DauSach> DS_DauSach { get; set; }
    }
}
