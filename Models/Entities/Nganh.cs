using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class Nganh
    {
        public int Id { get; set; }

        [DisplayName("Mã ngành")]
        public string MaNganh { get; set; }

        [DisplayName("Tên ngành")]
        public string TenNganh { get; set; }

        [DisplayName("Bộ môn")]
        public int BoMon_Id { get; set; }

        [DisplayName("Bộ môn")]
        public BoMon BoMon { get; set; }
        public List<Lop> Ds_Lop { get; set; }

    }
}
