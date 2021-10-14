using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLTV.AppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Controllers
{
    [Authorize]
    public class SachController : Controller
    {
        private readonly AppDbContext _context;

        public SachController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int DauSachId)
        {
            var dsSach =  _context.Sach.Where(s => s.DauSach_Id == DauSachId);

            ViewBag.DauSachId = DauSachId;
            ViewBag.tenDauSach = _context.DauSach.Find(DauSachId).TenDauSach;

            return View(dsSach.ToList());
        }
    }
}
