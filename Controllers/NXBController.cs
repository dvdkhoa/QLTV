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
    public class NXBController : Controller
    {
        private readonly AppDbContext _context;

        [TempData]
        public string StatusMessage { get; set; }

        public NXBController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NXB
        public async Task<IActionResult> Index()
        {
            return View(await _context.NXB.ToListAsync());
        }

        // GET: NXB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nXB = await _context.NXB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nXB == null)
            {
                return NotFound();
            }

            return View(nXB);
        }

        // GET: NXB/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NXB/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenNXB,DiaChi,Phone")] NXB nXB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nXB);
                await _context.SaveChangesAsync();
                StatusMessage = $"Tạo thành công NXB: {nXB.TenNXB}";
                return RedirectToAction(nameof(Index));
            }
            return View(nXB);
        }

        // GET: NXB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nXB = await _context.NXB.FindAsync(id);
            if (nXB == null)
            {
                return NotFound();
            }
            return View(nXB);
        }

        // POST: NXB/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenNXB,DiaChi,Phone")] NXB nXB)
        {
            if (id != nXB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nXB);
                    await _context.SaveChangesAsync();
                    StatusMessage = $"Cập nhật thành công NXB: {nXB.TenNXB}";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NXBExists(nXB.Id))
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
            return View(nXB);
        }

        // GET: NXB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nXB = await _context.NXB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nXB == null)
            {
                return NotFound();
            }

            return View(nXB);
        }

        // POST: NXB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nXB = await _context.NXB.FindAsync(id);

            bool exists = await _context.DauSach.AnyAsync(s => s.NXB_Id == nXB.Id);
            if(exists)
            {
                StatusMessage = "Error: Không thể xóa NXB này!!";
                return RedirectToAction("Delete");
            }    

            _context.NXB.Remove(nXB);
            await _context.SaveChangesAsync();
            StatusMessage = $"Xóa thành công NXB: {nXB.TenNXB}";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("/api/NXB/GetAll")]
        public IEnumerable<NXB> GetAll() => _context.NXB.ToList();

        private bool NXBExists(int id)
        {
            return _context.NXB.Any(e => e.Id == id);
        }
    }
}
