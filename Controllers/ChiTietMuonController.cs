using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTV.AppMVC.Models;
using QLTV.AppMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Controllers
{
    [Authorize(Roles = "Admin,Librarian")]
    public class ChiTietMuonController : Controller
    {
        private readonly AppDbContext _context;
        public ChiTietMuonController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
                return NotFound();

            var Ds_Ctm =await _context.ChiTietMuon.OrderByDescending(ctm=>ctm.Id).Where(ctm => ctm.PM_Id == id).ToListAsync();

            var pm = await _context.PhieuMuon.FindAsync(id);

            var sinhvien = await _context.SinhVien.FirstOrDefaultAsync(sv => sv.MaSV == pm.MaSV);

            ViewData["Id"] = id;
            ViewData["masv"] = sinhvien.MaSV;
            ViewData["tensv"] = sinhvien.TenSV;

            return View(Ds_Ctm);
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

            var sach = await _context.Sach.FindAsync(ctm.MaSach);
            sach.DangMuon = false;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { Id=ctm.PM_Id});
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return NotFound();
            var ctm = await _context.ChiTietMuon.FindAsync(Id);

            if (ctm == null)
                return NotFound();

            return View(ctm);
        }    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? Id)
        {
            var ctm = await _context.ChiTietMuon.FindAsync(Id);

            var sach = await _context.Sach.FindAsync(ctm.MaSach);
            sach.DangMuon = false;

            _context.ChiTietMuon.Remove(ctm);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index",new { Id=ctm.PM_Id});
        }
    }
}
