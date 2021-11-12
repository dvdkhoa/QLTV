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
            var dsPM = await (from pm in _context.PhieuMuon
                              select pm).ToListAsync();

            foreach (var pm in dsPM)
            {
                pm.DS_CTM = (from ctm in _context.ChiTietMuon
                             where ctm.PM_Id == pm.Id
                             select ctm).ToList();

                var ctmTreHan = from ctm in pm.DS_CTM
                                where ctm.NgayTra == null &&
                                DateTime.Compare(ctm.HanTra.Date, DateTime.Now.Date) < 0
                                select ctm;

                string message = "<h2>Bạn đã quá hạn trả sách</h2>";

                foreach (var ctm in ctmTreHan)
                {
                    message += @$"<hr>
                                    <p>Sách: <strong>{ctm.MaSach}</strong></p>
                                    <p>Ngày mượn: <strong>{ctm.NgayMuon}</strong></p>
                                    <p>Hạn trả: <strong>{ctm.HanTra}</strong></p>
                                    <p>Bạn đã quá hạn trả: <strong>{(DateTime.Now.Date - ctm.HanTra.Date).Days} ngày</strong></p>
                                    ";
                }
                message += "<h4>Vui lòng đến thư viện liên hệ thủ thư để trả sách !!!</h4>";

                string Email_SV = (await _context.SinhVien  // Lấy Email từ sinh viên
                                                          .Where(sv => sv.MaSV == pm.MaSV)
                                                          .FirstOrDefaultAsync()).Email;

                await _sendMailService.SendEmailAsync(Email_SV, "Trễ hạn trả sách", message);
                Console.WriteLine("Call SendMailService successfully !");
            };
        }
    }
}
