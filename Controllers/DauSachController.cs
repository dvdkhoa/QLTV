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
    public class DauSachController : Controller
    {
        private readonly AppDbContext _context;

        public DauSachController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DauSach
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.DauSach.Include(d => d.ChuDe).Include(d => d.HocPhan).Include(d => d.KeSach).Include(d => d.Khoa).Include(d => d.LoaiSach).Include(d => d.NXB).Include(d => d.NgonNgu).Include(d => d.TacGia);
            return View(await appDbContext.ToListAsync());
        }
      

        // GET: DauSach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dauSach = await _context.DauSach
                .Include(d => d.ChuDe)
                .Include(d => d.HocPhan)
                .Include(d => d.KeSach)
                .Include(d => d.Khoa)
                .Include(d => d.LoaiSach)
                .Include(d => d.NXB)
                .Include(d => d.NgonNgu)
                .Include(d => d.TacGia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dauSach == null)
            {
                return NotFound();
            }

            return View(dauSach);
        }

        // GET: DauSach/Create
        public IActionResult Create()
        {
            ViewData["ChuDe_Id"] = new SelectList(_context.ChuDe, "Id", "TenChuDe");
            ViewData["HocPhan_Id"] = new SelectList(_context.HocPhan, "Id", "TenHocPhan");
            ViewData["KeSach_Id"] = new SelectList(_context.KeSach, "Id", "TenKeSach");
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa");
            ViewData["LoaiSach_Id"] = new SelectList(_context.LoaiSach, "Id", "TenLoaiSach");
            ViewData["NXB_Id"] = new SelectList(_context.NXB, "Id", "TenNXB");
            ViewData["NgonNgu_Id"] = new SelectList(_context.NgonNgu, "Id", "TenNN");
            ViewData["TacGia_Id"] = new SelectList(_context.TacGia, "Id", "TenTG");
            return View();
        }

        // POST: DauSach/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaDauSach,TenDauSach,SL,LoaiSach_Id,ChuDe_Id,TacGia_Id,NXB_Id,NamXB,Khoa_Id,HocPhan_Id,KeSach_Id,SoTrang,KhoCo,Tags,MinhHoa,GiaBia,Nguon,TenKhac,TungThu,SoTap,TenTap,DinhKem,NgonNgu_Id,ISBN")] DauSach dauSach)
        {
            var exists = _context.DauSach.Any(ds => ds.MaDauSach == dauSach.MaDauSach);

            if (exists)
            {
                this.ModelState.AddModelError(string.Empty, "Mã đầu sách đã tồn tại");
                return View();
            }
            if (ModelState.IsValid)
            {
                _context.Add(dauSach); // Tạo đầu sách

                for (int i = 1; i <= dauSach.SL; i++)
                {
                    Sach s = new Sach();
                    s.MaSach = dauSach.MaDauSach + i;
                    s.DauSach_Id = dauSach.Id;
                    s.DauSach = dauSach;
                    s.DangMuon = false;

                    _context.Sach.Add(s);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChuDe_Id"] = new SelectList(_context.ChuDe, "Id", "TenChuDe", dauSach.ChuDe_Id);
            ViewData["HocPhan_Id"] = new SelectList(_context.HocPhan, "Id", "TenHocPhan", dauSach.HocPhan_Id);
            ViewData["KeSach_Id"] = new SelectList(_context.KeSach, "Id", "TenKeSach", dauSach.KeSach_Id);
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", dauSach.Khoa_Id);
            ViewData["LoaiSach_Id"] = new SelectList(_context.LoaiSach, "Id", "TenLoaiSach", dauSach.LoaiSach_Id);
            ViewData["NXB_Id"] = new SelectList(_context.NXB, "Id", "TenNXB", dauSach.NXB_Id);
            ViewData["NgonNgu_Id"] = new SelectList(_context.NgonNgu, "Id", "TenNN", dauSach.NgonNgu_Id);
            ViewData["TacGia_Id"] = new SelectList(_context.TacGia, "Id", "TenTG", dauSach.TacGia_Id);
            return View(dauSach);
        }

        // GET: DauSach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dauSach = await _context.DauSach.FindAsync(id);
            if (dauSach == null)
            {
                return NotFound();
            }
            ViewData["ChuDe_Id"] = new SelectList(_context.ChuDe, "Id", "TenChuDe", dauSach.ChuDe_Id);
            ViewData["HocPhan_Id"] = new SelectList(_context.HocPhan, "Id", "TenHocPhan", dauSach.HocPhan_Id);
            ViewData["KeSach_Id"] = new SelectList(_context.KeSach, "Id", "TenKeSach", dauSach.KeSach_Id);
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", dauSach.Khoa_Id);
            ViewData["LoaiSach_Id"] = new SelectList(_context.LoaiSach, "Id", "TenLoaiSach", dauSach.LoaiSach_Id);
            ViewData["NXB_Id"] = new SelectList(_context.NXB, "Id", "TenNXB", dauSach.NXB_Id);
            ViewData["NgonNgu_Id"] = new SelectList(_context.NgonNgu, "Id", "TenNN", dauSach.NgonNgu_Id);
            ViewData["TacGia_Id"] = new SelectList(_context.TacGia, "Id", "TenTG", dauSach.TacGia_Id);
            return View(dauSach);
        }

        // POST: DauSach/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaDauSach,TenDauSach,SL,LoaiSach_Id,ChuDe_Id,TacGia_Id,NXB_Id,NamXB,Khoa_Id,HocPhan_Id,KeSach_Id,SoTrang,KhoCo,Tags,MinhHoa,GiaBia,Nguon,TenKhac,TungThu,SoTap,TenTap,DinhKem,NgonNgu_Id,ISBN")] DauSach dauSach)
        {
            if (id != dauSach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dauSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DauSachExists(dauSach.Id))
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
            ViewData["ChuDe_Id"] = new SelectList(_context.ChuDe, "Id", "MaChuDe", dauSach.ChuDe_Id);
            ViewData["HocPhan_Id"] = new SelectList(_context.HocPhan, "Id", "Id", dauSach.HocPhan_Id);
            ViewData["KeSach_Id"] = new SelectList(_context.KeSach, "Id", "TenKeSach", dauSach.KeSach_Id);
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "Id", dauSach.Khoa_Id);
            ViewData["LoaiSach_Id"] = new SelectList(_context.LoaiSach, "Id", "MaLoaiSach", dauSach.LoaiSach_Id);
            ViewData["NXB_Id"] = new SelectList(_context.NXB, "Id", "Id", dauSach.NXB_Id);
            ViewData["NgonNgu_Id"] = new SelectList(_context.NgonNgu, "Id", "MaNN", dauSach.NgonNgu_Id);
            ViewData["TacGia_Id"] = new SelectList(_context.TacGia, "Id", "Id", dauSach.TacGia_Id);
            return View(dauSach);
        }

        // GET: DauSach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dauSach = await _context.DauSach.FirstOrDefaultAsync(m => m.Id == id);
            if (dauSach == null)
            {
                return NotFound();
            }

            return View(dauSach);
        }

        // POST: DauSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dauSach = await _context.DauSach.FindAsync(id);

            var ds_Sach = _context.Sach.Where(s => s.DauSach_Id == id).ToArray();

            _context.Sach.RemoveRange(ds_Sach);

            _context.DauSach.Remove(dauSach);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool DauSachExists(int id)
        {
            return _context.DauSach.Any(e => e.Id == id);
        }


        
        

        [HttpGet]
        public IActionResult NhapSach(int? Id)
        {
            if (Id == null)
                return NotFound();
            var dauSach = _context.DauSach.Find(Id);
            if (dauSach == null)
                return NotFound();

            ViewBag.Id = Id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhapSach(int Id,int SL)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var dauSach = await _context.DauSach.FindAsync(Id);
            if (dauSach == null)
                return NotFound();

            var index = dauSach.SL;

            for (int i = 1; i <= SL; i++)
            {
                Sach s = new Sach();
                s.MaSach = dauSach.MaDauSach + (index + i);
                s.DauSach_Id = dauSach.Id;
                s.DangMuon = false;

                await _context.Sach.AddAsync(s);
            }

            dauSach.SL = index + SL; // Cập nhật lại số lượng cho đầu sách

            await _context.SaveChangesAsync();

            return RedirectToAction("Edit",new { Id = Id });
        }


        [HttpGet]
        public IActionResult Tim(string tenSach)
        {
            if (tenSach==null)
            {
                return RedirectToAction("Index");
            }
            var ds_DauSach = _context.DauSach
                                .Include(s => s.TacGia)
                                .Include(s => s.KeSach)
                                .Where(s => s.TenDauSach
                                .Contains(tenSach));

            return View("Index", ds_DauSach.ToList());
        }


        [HttpGet("/api/DauSach")]
        public IEnumerable<object> GetDauSachByTen(string tenSach)
        {
            IEnumerable<object> kq = null;

            if (tenSach == null)
            {
               kq = _context.DauSach.Select(dauSach =>
               
               new { dauSach, 
                   soluongCoTheMuon = _context.Sach
                              .Count(s=>s.DauSach_Id==dauSach.Id&&s.DangMuon==false)});

                return kq.ToList();
            }

            var ds_Loc = _context.DauSach.Where(ds => ds.TenDauSach.Contains(tenSach));

            kq = ds_Loc.Select(dauSach => new
            {
                dauSach,
                soluongCoTheMuon = _context.Sach
                              .Count(s => s.DauSach_Id == dauSach.Id && s.DangMuon == false)
            });
            return kq;
        }
    }
}
