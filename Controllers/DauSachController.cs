using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV.AppMVC.Models;
using QLTV.AppMVC.Models.Entities;
using QLTV.AppMVC.Models.Helpers;

namespace QLTV.AppMVC.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Index(List<DauSach> dsDauSach, int p = 1)
        {
            if(!(dsDauSach.Count > 0))
                dsDauSach = _context.DauSach.Include(d => d.ChuDe).Include(d => d.HocPhan).Include(d => d.KeSach).Include(d => d.Khoa).Include(d => d.LoaiSach).Include(d => d.NXB).Include(d => d.NgonNgu).Include(d => d.TacGia).ToList();

            ViewData["paging"] = new Paging()
            {
                countPages = (int)Math.Ceiling((double)dsDauSach.Count / 10),
                currentPage = p,
                generateUrl = (int? p) => Url.Action("Index", new { p = p })
            };

            dsDauSach = dsDauSach.Skip((p - 1) * 10)
                    .Take(10).ToList();

            return View(dsDauSach);
        }
      

        // GET: DauSach/Details/5
        [AllowAnonymous]
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
            ViewData["ChuDe_Id"] = new SelectList(_context.ChuDe, "Id", "TenChuDe").Append(new SelectListItem() { Text="Chọn", Value="",Selected=true });
            ViewData["HocPhan_Id"] = new SelectList(_context.HocPhan, "Id", "TenHocPhan").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["KeSach_Id"] = new SelectList(_context.KeSach, "Id", "TenKeSach").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["LoaiSach_Id"] = new SelectList(_context.LoaiSach, "Id", "TenLoaiSach").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["NXB_Id"] = new SelectList(_context.NXB, "Id", "TenNXB").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["NgonNgu_Id"] = new SelectList(_context.NgonNgu, "Id", "TenNN").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["TacGia_Id"] = new SelectList(_context.TacGia, "Id", "TenTG").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
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
                
                loadCombobox();

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

            loadCombobox();

            return View(dauSach);
        }
        private void loadCombobox()
        {
            ViewData["ChuDe_Id"] = new SelectList(_context.ChuDe, "Id", "TenChuDe").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["HocPhan_Id"] = new SelectList(_context.HocPhan, "Id", "TenHocPhan").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["KeSach_Id"] = new SelectList(_context.KeSach, "Id", "TenKeSach").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["LoaiSach_Id"] = new SelectList(_context.LoaiSach, "Id", "TenLoaiSach").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["NXB_Id"] = new SelectList(_context.NXB, "Id", "TenNXB").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["NgonNgu_Id"] = new SelectList(_context.NgonNgu, "Id", "TenNN").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["TacGia_Id"] = new SelectList(_context.TacGia, "Id", "TenTG").Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
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
            ViewData["ChuDe_Id"] = new SelectList(_context.ChuDe, "Id", "TenChuDe", dauSach.ChuDe_Id).Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["HocPhan_Id"] = new SelectList(_context.HocPhan, "Id", "TenHocPhan", dauSach.HocPhan_Id).Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["KeSach_Id"] = new SelectList(_context.KeSach, "Id", "TenKeSach", dauSach.KeSach_Id).Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", dauSach.Khoa_Id).Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["LoaiSach_Id"] = new SelectList(_context.LoaiSach, "Id", "TenLoaiSach", dauSach.LoaiSach_Id).Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["NXB_Id"] = new SelectList(_context.NXB, "Id", "TenNXB", dauSach.NXB_Id).Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["NgonNgu_Id"] = new SelectList(_context.NgonNgu, "Id", "TenNN", dauSach.NgonNgu_Id).Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
            ViewData["TacGia_Id"] = new SelectList(_context.TacGia, "Id", "TenTG", dauSach.TacGia_Id).Append(new SelectListItem() { Text = "Chọn", Value = "", Selected = true });
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
        public IActionResult Tim(string tenSach,int? tacGiaId, int? KhoaId, int? chuDeId, int p=1)
        {
            if (tenSach == null && tacGiaId == null && KhoaId == null && chuDeId == null)
            {
                return RedirectToAction("Index");
            }
            var dsDauSach = _context.DauSach.Include(d=>d.TacGia)
                                             .Include(d=>d.KeSach)
                                             .ToList();
            
            if (KhoaId != null)
            {
                dsDauSach = dsDauSach.Where(d => d.Khoa_Id == KhoaId).ToList();
            } 
            if(tacGiaId != null)
            {
                dsDauSach = dsDauSach.Where(d => d.TacGia_Id == tacGiaId).ToList();
            }    
            if(chuDeId !=null )
            {
                dsDauSach = dsDauSach.Where(d => d.ChuDe_Id == chuDeId).ToList();
            }    

            if(!string.IsNullOrEmpty(tenSach))
            {
                dsDauSach = dsDauSach
                                .Where(s => s.TenDauSach.ToLower()
                                .Contains(tenSach.ToLower())).ToList();
            }

            ViewData["paging"] = new Paging()
            {                 
                countPages = (int)Math.Ceiling((double)dsDauSach.Count() / 10),
                currentPage = p,
                generateUrl = (int? p) => Url.Action("Tim", new { p = p, khoaid=KhoaId, chuDeId=chuDeId, tacGiaId=tacGiaId, tenSach=tenSach})
            };

            dsDauSach = dsDauSach.Skip((p - 1) * 10)
                    .Take(10).ToList();

            return View("Index", dsDauSach);
        }

        [HttpGet("/api/dausach")]
        public IActionResult GetDauSach(string tenSach, string tags, string tenTG, int? KhoaId)
        {
            var ds = _context.DauSach.Select(d=> new {
                d.MaDauSach,
                d.TenDauSach,
                d.TenKhac,
                d.ImagePath,
                d.ChuDe.TenChuDe,
                d.HocPhan.TenHocPhan,
                d.ISBN,
                d.KeSach.TenKeSach,
                d.Khoa.TenKhoa,
                d.KhoCo,
                d.LoaiSach.TenLoaiSach,
                d.MinhHoa,
                d.NamXB,
                d.NgonNgu.TenNN,
                d.Nguon,
                d.NXB.TenNXB,
                d.SL,
                d.SoTap,
                d.SoTrang,
                d.TacGia.TenTG,
                d.Tags,
                d.TenTap,
                d.TungThu,
                soluongconlai = _context.Sach.Count(s => s.DauSach_Id == d.Id)
            }).ToList();
            object obj = null;

            if (string.IsNullOrEmpty(tenSach) 
                && string.IsNullOrEmpty(tags) 
                && string.IsNullOrEmpty(tenTG)
                && KhoaId==null)
            {
                obj = ds;   
            }

            // Tìm sách theo Khoa
            if(KhoaId!=null)
            {
                var khoa=_context.Khoa.Find(KhoaId);
                if (khoa is null)
                    return Json("Khoa không tồn tại");
                obj = ds.Where(d => d.TenKhoa == khoa.TenKhoa);
            }    

            if (!string.IsNullOrEmpty(tenSach))
            {
                obj = ds.Where(d => d.TenDauSach.ToLower().Contains(tenSach.ToLower()));
            }

            if (!string.IsNullOrEmpty(tags))
            {
                obj = ds.Where(d => {
                    if (d.Tags is null)
                        return false;
                    return d.Tags.ToLower().Contains(tags.ToLower());
                });
            }

            if(!string.IsNullOrEmpty(tenTG))
            {
                obj = ds.Where(d => d.TenTG.ToLower().Contains(tenTG.ToLower()));
            }
            
            return Json(obj);
        }
        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult TimAjax(string keyword)
        {
            var ds = _context.DauSach
                .Where(d => d.TenDauSach.ToLower().Contains(keyword))
                .Include(d=>d.KeSach)
                .Include(d=>d.TacGia);

            return PartialView(ds.ToList());
        }
    }
}
