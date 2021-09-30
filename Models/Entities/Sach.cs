using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Models.Entities
{
    public class Sach
    {
        public int Id { get; set; }
        public int DauSach_Id { get; set; }
        public DauSach DauSach { get; set; }
        public bool DangMuon { get; set; }
    }
}
