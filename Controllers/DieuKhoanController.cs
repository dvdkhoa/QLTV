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
    [Authorize(Roles = "Admin")]
    public class DieuKhoanController : Controller
    {
        private readonly AppDbContext _context;
        public DieuKhoanController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.DieuKhoan.OrderByDescending(d=>d.Id).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DieuKhoan dieuKhoan)
        {
            if(ModelState.IsValid)
            {
                dieuKhoan.NgayBD = DateTime.Now;

                await _context.DieuKhoan.AddAsync(dieuKhoan);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Nhập đầy đủ thông tin yêu cầu !!!");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dk = await _context.DieuKhoan.FindAsync(id);
            if (dk == null)
                return NotFound();

            return View(dk);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dk = await _context.DieuKhoan.FindAsync(id);

            _context.DieuKhoan.Remove(dk);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
