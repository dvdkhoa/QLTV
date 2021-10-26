using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV.AppMVC.Models;
using QLTV.AppMVC.Models.Entities;

namespace QLTV.AppMVC.Controllers
{
    [Authorize]
    public class PhieuMuonController : Controller
    {
        private readonly AppDbContext _context;

        public PhieuMuonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PhieuMuon
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PhieuMuon.Include(p => p.SinhVien);
            return View(await appDbContext.ToListAsync());
        }


        // GET: PhieuMuon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhieuMuon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string masv, string masach)
        {
            if (ModelState.IsValid)
            {
                var sv = await  _context.SinhVien.Where(sv => sv.MaSV == masv)
                                                .FirstOrDefaultAsync();

                var sach = await _context.Sach.FirstOrDefaultAsync(s => s.MaSach == masach);

                // Kiểm tra sinh viên
                if (sv == null)
                {
                    ModelState.AddModelError(string.Empty, "Sinh viên không tồn tại");
                    return View();
                }

                /******************************************/
                if (sach == null) //Kiểm tra sách
                {
                    ModelState.AddModelError(string.Empty, "Sách không tồn tại");
                    return View();
                }
                if(sach.DangMuon)
                {
                    ModelState.AddModelError(string.Empty, "Sách đang được mượn, vui lòng chọn mã sách khác");
                    return View();
                }

                // Lấy số ngày trong điều khoản mới nhất
                var soNgay = await (from d in _context.DieuKhoan 
                                    orderby d.Id descending
                                    select d.ThoiHan).FirstOrDefaultAsync();
                ChiTietMuon c = new ChiTietMuon() // Tạo chi tiết mượn trước
                {
                    MaSach = masach,
                    NgayMuon = DateTime.Now,
                    HanTra = DateTime.Now.AddDays(soNgay)
                };
                sach.DangMuon = true;

                var PM_exists = await _context.PhieuMuon.FirstOrDefaultAsync(pm => pm.MaSV == sv.MaSV);

                if(PM_exists == null)  // Nếu phiếu mượn chưa tồn tại => tạo mới
                {
                    PhieuMuon pm = new PhieuMuon()
                    {
                        SinhVien = sv,
                        MaSV = sv.MaSV
                    };
                    await _context.AddAsync(pm);
                    
                    c.PhieuMuon = pm;
                }
                else // Nếu phiếu mượn tồn tại
                {
                    var slSach_chuatra = await _context.ChiTietMuon.Where(ctm => ctm.PM_Id == PM_exists.Id)
                                        .CountAsync(ctm => ctm.NgayTra == null);
                    var slSachToiDa = await _context.DieuKhoan.OrderByDescending(d=>d.Id).Select(d => d.SLSach).FirstOrDefaultAsync();

                    if (slSach_chuatra >= slSachToiDa)
                    {
                        ModelState.AddModelError(string.Empty, $"Hiện tại thư viện chỉ cho mượn tối đa {slSachToiDa} quyển và sinh viên {masv} đã đạt ngưỡng tối đa.");
                        return View();
                    }    
                    c.PhieuMuon = PM_exists;
                }

                await _context.ChiTietMuon.AddAsync(c); // Thêm chi tiết mượn
                await _context.SaveChangesAsync(); // Lưu vào database

                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Vui lòng nhập đầy đủ thông tin");
            return View();
        }


        // GET: PhieuMuon/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var phieuMuon = await _context.PhieuMuon
        //        .Include(p => p.SinhVien)
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    if (phieuMuon == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(phieuMuon);
        //}

        //// POST: PhieuMuon/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var phieuMuon = await _context.PhieuMuon.FindAsync(id);

        //    var ds_ctm = _context.ChiTietMuon.Where(ctm => ctm.PM_Id == id)
        //                                        .Include(ctm =>ctm.Sach);

        //    // Xóa tất cả chi tiết mượn có PM_Id=Id
        //    foreach (var ctm in ds_ctm)
        //    {
        //        ctm.Sach.DangMuon = false;

        //        _context.ChiTietMuon.Remove(ctm);
        //    }

        //    _context.PhieuMuon.Remove(phieuMuon);

        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]
        public IActionResult Tim(string maSV)
        {
            if (maSV == null)
                return RedirectToAction("Index"); 

            var pm = _context.PhieuMuon.Where(pm => pm.SinhVien.MaSV == maSV);

            return View("Index", pm.Include(pm=>pm.SinhVien).ToList());
        }

        private bool PhieuMuonExists(int id)
        {
            return _context.PhieuMuon.Any(e => e.Id == id);
        }
    }
}
