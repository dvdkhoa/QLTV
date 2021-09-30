using Microsoft.AspNetCore.Mvc;
using QLTV.AppMVC.Models;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Controllers
{
    public class ChiTietMuonController : Controller
    {
        private readonly AppDbContext _context;
        public ChiTietMuonController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
            if (id == null)
                return NotFound();

            var Ds_Ctm = _context.ChiTietMuon.Where(ctm => ctm.PM_Id == id).ToList();

            ViewData["Id"] = id;

            return View(Ds_Ctm);
        }
        public IActionResult Create(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int Id,[Bind("Sach_Id,NgayMuon")]ChiTietMuon ctm)
        {
            var sach = _context.Sach.Find(ctm.Sach_Id);

            if(sach==null)
            {
                ModelState.AddModelError(string.Empty, "Sách không tồn tại");

                ViewBag.Id = Id;
                return View();
            }

            var pm =  _context.PhieuMuon.Find(Id);
            
            ctm.PM_Id = pm.Id;
            ctm.NgayTra = null;

            _context.ChiTietMuon.Add(ctm);

            sach.DangMuon = true; // Cập nhật trạng thái của sách (đang mượn??)

            _context.SaveChanges();
            
            return RedirectToAction("Index",new { Id = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TraSach(int? Id)
        {
            if (Id == null)
                return NotFound();

            var ctm = await _context.ChiTietMuon.FindAsync(Id);

            if (ctm == null)
                return NotFound();

            ctm.NgayTra = DateTime.Now;

            var sach = await _context.Sach.FindAsync(ctm.Sach_Id);
            sach.DangMuon = false;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { Id=ctm.PM_Id});
        }

        
    }
}
