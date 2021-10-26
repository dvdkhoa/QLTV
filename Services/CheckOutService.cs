using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using QLTV.AppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Services
{
    public class CheckOutService
    {
        private readonly AppDbContext _context;
        private readonly IEmailSender _sendMailService;


        public CheckOutService(IEmailSender sendMailService, AppDbContext context)
        {
            _sendMailService = sendMailService;
            _context = context;
        }
        public async Task SendMailSinhVien()
        {
            var qr = (from pm in _context.PhieuMuon // Lấy tất cả các chi tiết mượn quá hạn trả sách
                      join sv in _context.SinhVien on pm.MaSV equals sv.MaSV
                      join ctm in _context.ChiTietMuon on pm.Id equals ctm.PM_Id
                      select new { pm, sv, ctm }).AsQueryable();

            var list = await qr.ToListAsync();

            list.ForEach(async a =>
            {
                if (a.ctm.NgayTra == null)
                {
                    var kq = DateTime.Compare(DateTime.Now.Date, a.ctm.HanTra.Date);
                    if (kq > 0) // Sinh viên chưa trả sách
                    {
                        await _sendMailService.SendEmailAsync(a.sv.Email
                             , "!!!Quá hạn trả sách",
                             @$"<h2>Bạn đã quá hạn trả sách</h2>
                                    <hr>
                                    <p>Sách: <strong>{a.ctm.MaSach}</strong></p>
                                    <p>Ngày mượn: <strong>{a.ctm.NgayMuon}</strong></p>
                                    <p>Hạn trả: <strong>{a.ctm.HanTra}</strong></p>
                                    <p>Bạn đã quá hạn trả: <strong>{(DateTime.Now.Date - a.ctm.HanTra.Date).Days} ngày</strong></p>
                                    <h4>Vui lòng đến thư viện liên hệ thủ thư để trả sách !!!</h4>");

                        Console.WriteLine($"Successfully {a.sv.Email}"); // Gửi xong cho mail sinh viên nào ??
                    }
                }
            });
            Console.WriteLine("Send mail Successfully!"); // Hoàn tất việc gửi mail và kết thúc Job này.
        }
    }
}
