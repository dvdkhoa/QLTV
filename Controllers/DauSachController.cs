using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment _env;

        public DauSachController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
        public async Task<IActionResult> Create([Bind("Id,MaDauSach,TenDauSach,ImageFile,SL,LoaiSach_Id,ChuDe_Id,TacGia_Id,NXB_Id,NamXB,Khoa_Id,HocPhan_Id,KeSach_Id,SoTrang,KhoCo,Tags,MinhHoa,GiaBia,Nguon,TenKhac,TungThu,SoTap,TenTap,DinhKem,NgonNgu_Id,ISBN")] DauSach dauSach)
        {
            var exists = _context.DauSach.Any(ds => ds.MaDauSach == dauSach.MaDauSach);

            if (exists)
            {
                this.ModelState.AddModelError(string.Empty, "Mã đầu sách đã tồn tại");
                return View();
            }
            if (ModelState.IsValid)
            {
                if(dauSach.ImageFile != null)
                {
                    await Uploads(dauSach);
                }    
                
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

        public async Task Uploads(DauSach dauSach)
        {
            var fileName = dauSach.ImageFile.FileName;
            fileName = fileName.Substring(fileName.LastIndexOf("."));
            fileName = dauSach.MaDauSach + fileName;

            var imagePath = Path.Combine(_env.WebRootPath, "imgs", fileName);

            using var fileStream = new FileStream(imagePath, FileMode.Create);

            await dauSach.ImageFile.CopyToAsync(fileStream);

            dauSach.ImagePath = Path.Combine("/imgs",fileName);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaDauSach,TenDauSach, ImagePath,ImageFile,SL,LoaiSach_Id,ChuDe_Id,TacGia_Id,NXB_Id,NamXB,Khoa_Id,HocPhan_Id,KeSach_Id,SoTrang,KhoCo,Tags,MinhHoa,GiaBia,Nguon,TenKhac,TungThu,SoTap,TenTap,DinhKem,NgonNgu_Id,ISBN")] DauSach dauSach)
        {
            if (id != dauSach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(dauSach.ImageFile!=null)
                    {
                        await Uploads(dauSach);
                    }    

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

            _context.Sach.RemoveRange(ds_Sach); // Xóa danh sách sách thuộc đầu sách

            if(System.IO.File.Exists(dauSach.ImagePath))
            {
                System.IO.File.Delete(dauSach.ImagePath); // Xóa Image của đầu sách
            }    

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

        [HttpGet("/api/GetDauSachByTG")]
        public List<IEnumerable<object>> GetDauSachByTG(string tentg)
        {
            var dsTG = _context.TacGia.Where(tg => tg.TenTG.Contains(tentg));

            List<IEnumerable<object>> kq = null;

            foreach (var tg in dsTG)
            {
               var a =  _context.DauSach.Where(d=>d.TacGia_Id == tg.Id)
                                .Select(dauSach => new
                                {
                                    dauSach,
                                    soluongCoTheMuon = _context.Sach
                                                  .Count(s => s.DauSach_Id == dauSach.Id && s.DangMuon == false)
                                }).ToList();
                kq.Add(a);
            }

            return kq;
        }

        [HttpGet("/api/DauSach")]
        public IEnumerable<object> GetDauSach(string tenSach, string tags)
        {
            IEnumerable<object> kq = null;

            if (tenSach == null && tags == null)
            {
               kq = _context.DauSach.Select(dauSach =>
               
               new { dauSach, 
                   soluongCoTheMuon = _context.Sach
                              .Count(s=>s.DauSach_Id==dauSach.Id&&s.DangMuon==false)});

                return kq.ToList();
            }

            IQueryable<DauSach> ds_Loc = _context.DauSach;

            if (!string.IsNullOrEmpty(tenSach)) 
            {
                ds_Loc = ds_Loc.Where(ds => ds.TenDauSach.Contains(tenSach));

                kq = ds_Loc.Select(dauSach => new
                {
                    dauSach,
                    soluongCoTheMuon = _context.Sach
                                  .Count(s => s.DauSach_Id == dauSach.Id && s.DangMuon == false)
                });
            }    

            if(!string.IsNullOrEmpty(tags))
            {
                ds_Loc = ds_Loc.Where(ds => ds.Tags.Contains(tags));

                kq = ds_Loc.Select(dauSach => new
                {
                    dauSach,
                    soluongCoTheMuon = _context.Sach
                                  .Count(s => s.DauSach_Id == dauSach.Id && s.DangMuon == false)
                });
            }

            return kq.ToList();
        }
    }
}
