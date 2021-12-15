﻿using System;
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
    [Authorize(Roles = "Admin,Librarian")]
    public class HocPhanController : Controller
    {
        private readonly AppDbContext _context;

        [TempData]
        public string StatusMessage { get; set; }

        public HocPhanController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HocPhan
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet("/api/hocphan/getall")]
        public List<HocPhan> getAll()
        {
            return _context.HocPhan.ToList();
        }

        // GET: HocPhan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhan
                .Include(h => h.Khoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hocPhan == null)
            {
                return NotFound();
            }

            return View(hocPhan);
        }

        // GET: HocPhan/Create
        public IActionResult Create()
        {
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa");
            return View();
        }

        // POST: HocPhan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaHocPhan,TenHocPhan,Khoa_Id")] HocPhan hocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocPhan);
                await _context.SaveChangesAsync();
                StatusMessage = $"Thêm thành công học phần: {hocPhan.TenHocPhan}";
                return RedirectToAction(nameof(Index));
            }
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "Id", hocPhan.Khoa_Id);
            return View(hocPhan);
        }

        // GET: HocPhan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhan.FindAsync(id);
            if (hocPhan == null)
            {
                return NotFound();
            }
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", hocPhan.Khoa_Id);
            return View(hocPhan);
        }

        // POST: HocPhan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaHocPhan,TenHocPhan,Khoa_Id")] HocPhan hocPhan)
        {
            if (id != hocPhan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocPhanExists(hocPhan.Id))
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
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "Id", hocPhan.Khoa_Id);
            return View(hocPhan);
        }

        // GET: HocPhan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhan
                .Include(h => h.Khoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hocPhan == null)
            {
                return NotFound();
            }

            return View(hocPhan);
        }

        // POST: HocPhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hocPhan = await _context.HocPhan.FindAsync(id);
            bool exists = await _context.DauSach.AnyAsync(s => s.HocPhan_Id == hocPhan.Id);
            if (exists)
            {
                StatusMessage = $"Error: Không thể xóa học phần {hocPhan.TenHocPhan}!!";
                return RedirectToAction("Delete");
            }
            _context.HocPhan.Remove(hocPhan);
            await _context.SaveChangesAsync();
            StatusMessage = $"Xóa thành công học phần: {hocPhan.TenHocPhan}";
            return RedirectToAction(nameof(Index));
        }

        private bool HocPhanExists(int id)
        {
            return _context.HocPhan.Any(e => e.Id == id);
        }
    }
}
