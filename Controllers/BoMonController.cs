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
    [Authorize(Roles = "Admin")]
    public class BoMonController : Controller
    {
        private readonly AppDbContext _context;

        [TempData]
        public string StatusMessage { get; set; }

        public BoMonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BoMon
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/api/bomon/getall")]
        public List<BoMon> getAll()
        {
            return _context.BoMon.ToList();
        }
        // GET: BoMon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boMon = await _context.BoMon
                .Include(b => b.Khoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boMon == null)
            {
                return NotFound();
            }

            return View(boMon);
        }

        // GET: BoMon/Create
        public IActionResult Create()
        {

            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa");
            return View();
        }

        // POST: BoMon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaBoMon,TenBoMon,Khoa_Id")] BoMon boMon)
        {
            if (ModelState.IsValid)
            {
                var exists = await _context.BoMon.AnyAsync(bm => bm.MaBoMon == boMon.MaBoMon);

                if(exists)
                {
                    ModelState.AddModelError(string.Empty, "Mã bộ môn bị trùng");
                    return View();
                }    

                _context.Add(boMon);
                await _context.SaveChangesAsync();

                StatusMessage = $"Thêm thành công bộ môn: {boMon.TenBoMon}";

                return RedirectToAction(nameof(Index));
            }
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", boMon.Khoa_Id);
            return View(boMon);
        }

        // GET: BoMon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boMon = await _context.BoMon.FindAsync(id);
            if (boMon == null)
            {
                return NotFound();
            }
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", boMon.Khoa_Id);
            return View(boMon);
        }

        // POST: BoMon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaBoMon,TenBoMon,Khoa_Id")] BoMon boMon)
        {
            if (id != boMon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var bm_cu = await _context.BoMon.FindAsync(id);

                    if(bm_cu.MaBoMon!=boMon.MaBoMon)
                    {
                        var exists = await _context.BoMon.AnyAsync(bm => bm.MaBoMon == boMon.MaBoMon);
                        if(exists)
                        {
                            ModelState.AddModelError(string.Empty, "Mã bộ môn bị trùng");
                            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", boMon.Khoa_Id);
                            return View();
                        }    
                    }
                    bm_cu.MaBoMon = boMon.MaBoMon;
                    bm_cu.TenBoMon = boMon.TenBoMon;
                    bm_cu.Khoa_Id = boMon.Khoa_Id;

                    await _context.SaveChangesAsync();
                    StatusMessage = $"Cập nhật thành công bộ môn: {boMon.TenBoMon}";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoMonExists(boMon.Id))
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
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "Id", boMon.Khoa_Id);
            return View(boMon);
        }

        // GET: BoMon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boMon = await _context.BoMon
                .Include(b => b.Khoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boMon == null)
            {
                return NotFound();
            }

            return View(boMon);
        }

        // POST: BoMon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boMon = await _context.BoMon.FindAsync(id);
            _context.BoMon.Remove(boMon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoMonExists(int id)
        {
            return _context.BoMon.Any(e => e.Id == id);
        }
    }
}
