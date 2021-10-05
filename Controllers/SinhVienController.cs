using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV.AppMVC.Models;
using QLTV.AppMVC.Models.Entities;

namespace QLTV.AppMVC.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly AppDbContext _context;

        public SinhVienController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SinhVien
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SinhVien.Include(s => s.Khoa).Include(s => s.Lop).Include(s => s.Nganh);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SinhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.Khoa)
                .Include(s => s.Lop)
                .Include(s => s.Nganh)
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhVien/Create
        public IActionResult Create()
        {
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa");
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "Id", "MaLop");
            ViewData["Nganh_Id"] = new SelectList(_context.Nganh, "Id", "TenNganh");
            return View();
        }

        // POST: SinhVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSV,TenSV,NgaySinh,GioiTinh,Phone,Lop_Id,Nganh_Id,Khoa_Id")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                var exists = await _context.SinhVien.AnyAsync(k => k.MaSV == sinhVien.MaSV);
                if (exists)
                {
                    ModelState.AddModelError(string.Empty, "Mã sinh viên bị trùng");
                    return View();
                }

                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", sinhVien.Khoa_Id);
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "Id", "MaLop", sinhVien.Lop_Id);
            ViewData["Nganh_Id"] = new SelectList(_context.Nganh, "Id", "TenNganh", sinhVien.Nganh_Id);
            return View(sinhVien);
        }

        // GET: SinhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", sinhVien.Khoa_Id);
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "Id", "MaLop", sinhVien.Lop_Id);
            ViewData["Nganh_Id"] = new SelectList(_context.Nganh, "Id", "TenNganh", sinhVien.Nganh_Id);
            return View(sinhVien);
        }

        // POST: SinhVien/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSV,TenSV,NgaySinh,GioiTinh,Phone,Lop_Id,Nganh_Id,Khoa_Id")] SinhVien sinhVien)
        {
            if (id != sinhVien.MaSV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.MaSV))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", sinhVien.Khoa_Id);
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "Id", "MaLop", sinhVien.Lop_Id);
            ViewData["Nganh_Id"] = new SelectList(_context.Nganh, "Id", "TenNganh", sinhVien.Nganh_Id);
            return View(sinhVien);
        }

        // GET: SinhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.Khoa)
                .Include(s => s.Lop)
                .Include(s => s.Nganh)
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhVien = await _context.SinhVien.FindAsync(id);
            _context.SinhVien.Remove(sinhVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
            return _context.SinhVien.Any(e => e.MaSV == id);
        }
    }
}
