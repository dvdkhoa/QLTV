using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using QLTV.AppMVC.Models;
using QLTV.AppMVC.Models.Entities;

namespace QLTV.AppMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SinhVienController : Controller
    {
        private readonly AppDbContext _context;

        public SinhVienController(AppDbContext context)
        {
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        // GET: SinhVien
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SinhVien.Include(s => s.Lop);
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
                .Include(s => s.Lop)
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
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "Id", "MaLop");
            return View();
        }

        // POST: SinhVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SinhVien sinhVien)
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
                StatusMessage = $"Thêm thành công sinh viên: {sinhVien.TenSV}";
                return RedirectToAction(nameof(Index));
            }
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "Id", "MaLop", sinhVien.Lop_Id);
            return View(sinhVien);
        }

        [HttpPost]
        public async Task<IActionResult> ImportFromExcel(IFormFile file)
        {
            List<SinhVien> dsSV = new List<SinhVien>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
                    var rowCount = workSheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var masv = workSheet.Cells[row, 1].Value.ToString().Trim();
                        var exists = await _context.SinhVien.AnyAsync(sv => sv.MaSV == masv);
                        if (exists)
                            continue;

                        var lop = await _context.Lop.Where(l => l.MaLop == workSheet.Cells[row, 7].Value.ToString().Trim()).FirstOrDefaultAsync();

                        dsSV.Add(new SinhVien()
                        {
                            MaSV = workSheet.Cells[row,1].Value.ToString().Trim(),
                            TenSV = workSheet.Cells[row, 2].Value.ToString().Trim(),
                            Email = workSheet.Cells[row, 3].Value.ToString().Trim(),
                            NgaySinh = DateTime.ParseExact(workSheet.Cells[row, 4].Value.ToString().Trim(), "dd/M/yyyy", CultureInfo.InvariantCulture),
                            GioiTinh = workSheet.Cells[row, 5].Value.ToString().Trim(),
                            Phone = workSheet.Cells[row, 6].Value.ToString().Trim(),
                            Lop_Id = lop.Id
                        });
                    }
                }
                _context.SinhVien.AddRange(dsSV);
                await _context.SaveChangesAsync();

                StatusMessage = "Vừa cập nhật sinh viên từ file Excel thành công !";
                return RedirectToAction("Index");
            }
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
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "Id", "MaLop", sinhVien.Lop_Id);
            return View(sinhVien);
        }

        // POST: SinhVien/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,  SinhVien sinhVien)
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
            ViewData["Lop_Id"] = new SelectList(_context.Lop, "Id", "MaLop", sinhVien.Lop_Id);
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
                .Include(s => s.Lop)
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
            var pm = await _context.PhieuMuon.FirstOrDefaultAsync(pm => pm.MaSV == sinhVien.MaSV);
            if(pm != null)
            {
                StatusMessage = $"Error: Không thể xóa sinh viên: {sinhVien.TenSV} !!!";
                return RedirectToAction("Delete");
            }    
            _context.SinhVien.Remove(sinhVien);
            await _context.SaveChangesAsync();
            StatusMessage = $"Xóa thành công sinh viên {sinhVien.TenSV}";
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
            return _context.SinhVien.Any(e => e.MaSV == id);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> TimAjax(string masv)
        {
            var sv = await _context.SinhVien.Where(sv => sv.MaSV == masv).FirstOrDefaultAsync();
            if (sv != null)
                return PartialView("_TimAjax", sv);
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var qr = from sv in _context.SinhVien
                     select new
                     {
                         sv.MaSV,
                         sv.TenSV,
                         maLop = _context.Lop.Where(l=>l.Id==sv.Lop_Id).FirstOrDefault().MaLop,
                         NgaySinh = sv.NgaySinh.ToString("dd/MM/yyyy"),
                         sv.GioiTinh
                     };

            return Json(qr.ToList());
        }

    }
}
