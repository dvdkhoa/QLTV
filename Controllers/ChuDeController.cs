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
    [Authorize(Roles = "Admin,Librarian")]
    public class ChuDeController : Controller
    {
        private readonly AppDbContext _context;

        public ChuDeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ChuDe
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChuDe.ToListAsync());
        }

        // GET: ChuDe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuDe = await _context.ChuDe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chuDe == null)
            {
                return NotFound();
            }

            return View(chuDe);
        }

        // GET: ChuDe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChuDe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaChuDe,TenChuDe")] ChuDe chuDe)
        {
            if (ModelState.IsValid)
            {
                var exists = await _context.ChuDe.AnyAsync(k => k.MaChuDe == chuDe.MaChuDe);
                if (exists)
                {
                    ModelState.AddModelError(string.Empty, "Mã chủ đề bị trùng");
                    return View();
                }

                _context.Add(chuDe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chuDe);
        }

        // GET: ChuDe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuDe = await _context.ChuDe.FindAsync(id);
            if (chuDe == null)
            {
                return NotFound();
            }
            return View(chuDe);
        }

        // POST: ChuDe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaChuDe,TenChuDe")] ChuDe chuDe)
        {
            if (id != chuDe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var chuDe_cu = await _context.ChuDe.FindAsync(id);
                    bool exists = false;

                    var ds_chude =  _context.ChuDe.Where(c => c.MaChuDe != chuDe_cu.MaChuDe).ToList();

                    foreach (var c in ds_chude)
                    {
                        if(c.MaChuDe==chuDe.MaChuDe)
                        {
                            exists = true;
                            break;
                        }    
                    }

                    if(exists) // Nếu mã chủ đề tồn tại
                    {
                        ModelState.AddModelError(string.Empty, "Mã chủ đề bị trùng");
                        return View();
                    }

                    chuDe_cu.MaChuDe = chuDe.MaChuDe;
                    chuDe_cu.TenChuDe = chuDe.TenChuDe;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuDeExists(chuDe.Id))
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
            return View(chuDe);
        }

        // GET: ChuDe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuDe = await _context.ChuDe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chuDe == null)
            {
                return NotFound();
            }

            return View(chuDe);
        }

        // POST: ChuDe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chuDe = await _context.ChuDe.FindAsync(id);
            _context.ChuDe.Remove(chuDe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChuDeExists(int id)
        {
            return _context.ChuDe.Any(e => e.Id == id);
        }


        [HttpGet]
        [Route("/Api/Chude/[Action]")]
        public IEnumerable<ChuDe> GetAll() => _context.ChuDe.ToList();
    }
}
