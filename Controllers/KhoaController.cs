using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QLTV.AppMVC.Models;
using QLTV.AppMVC.Models.Entities;

namespace QLTV.AppMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KhoaController : Controller
    {
        private readonly AppDbContext _context;

        private readonly ILogger<KhoaController> _logger;

        [TempData]
        public string StatusMessage { get; set; }

        public KhoaController(ILogger<KhoaController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        // GET: khoa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Khoa.OrderBy(k=>k.MaKhoa).ToListAsync());
        }

        // GET: khoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khoa == null)
            {
                return NotFound();
            }

            return View(khoa);
        }

        // GET: khoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: khoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaKhoa,TenKhoa")] Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                var exists =await _context.Khoa.AnyAsync(k => k.MaKhoa == khoa.MaKhoa);
                if(exists)
                {
                    ModelState.AddModelError(string.Empty, "Mã khoa bị trùng");
                    return View();
                }    

                var a = _context.Khoa.Add(khoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoa);
        }

        // GET: khoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoa.FindAsync(id);
            if (khoa == null)
            {
                return NotFound();
            }
            return View(khoa);
        }

        // POST: khoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaKhoa,TenKhoa")] Khoa khoa)
        {
            if (id != khoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var khoa_cu = await _context.Khoa.FindAsync(id); // Lấy giá trí cũ

                    var ds_Khoa = await _context.Khoa.Where(k => k.MaKhoa != khoa_cu.MaKhoa)
                                                .ToListAsync(); // Lấy ra tất cả khoa khác khoa cũ

                    var exists = false;
                    ds_Khoa.ForEach(k =>
                    {
                        if (k.MaKhoa == khoa.MaKhoa)
                        {
                            exists = true;
                        }    
                    });

                    if(exists) // Nếu mã khoa tồn tại
                    {
                        ModelState.AddModelError(string.Empty, "Mã khoa bị trùng");
                        return View();
                    }
                    khoa_cu.TenKhoa = khoa.TenKhoa;
                    khoa_cu.MaKhoa = khoa.MaKhoa;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoaExists(khoa.Id))
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
            return View(khoa);
        }

        // GET: khoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var khoa = await _context.Khoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khoa == null)
            {
                return NotFound();
            }

            return View(khoa);
        }

        // POST: khoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khoa = await _context.Khoa.FindAsync(id);
            _context.Khoa.Remove(khoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoaExists(int id)
        {
            return _context.Khoa.Any(e => e.Id == id);
        }


        [HttpGet("/api/Khoa/GetAll")]
        public IEnumerable<Khoa> GetAll() => _context.Khoa.ToList();
    }
}
