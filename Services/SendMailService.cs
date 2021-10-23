using System;
using MimeKit;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using QLTV.AppMVC.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLTV.AppMVC.Services
{
    public class SendMailService: IEmailSender
    {
        private readonly MailSettings _mailSettings;
        private readonly AppDbContext _context;
        public SendMailService(IOptions<MailSettings> mailSettings,AppDbContext context)
        {
            _mailSettings = mailSettings.Value;
            _context = context;
        }

        public class MailContent
        {
            public string To { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }
        }

        public async Task SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
            
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            
            email.To.Add(new MailboxAddress(mailContent.To, mailContent.To));
            email.Subject = mailContent.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Content;

            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.PassWord);
                await smtp.SendAsync(email);
            }
            catch(Exception ex)
            {
                Console.WriteLine("gửi mail thất bai !!!!!!!");
                Console.WriteLine(ex.Message);
                return;
            }
            smtp.Disconnect(true);
            Console.WriteLine("gửi mail thành công !!!");
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mess = new MimeMessage();
            mess.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);

            mess.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));

            mess.To.Add(MailboxAddress.Parse(email));
            mess.Subject = subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = htmlMessage;

            mess.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.PassWord);
                await smtp.SendAsync(mess);
            }
            catch (Exception ex)
            {
                Console.WriteLine("gửi mail thất bai !!!!!!!");
                Console.WriteLine(ex.Message);
            }
            smtp.Disconnect(true);
            Console.WriteLine("gửi mail thành công !!!");
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
                           await this.SendEmailAsync(a.sv.Email
                                , "!!!Quá hạn trả sách",
                                @$"<h2>Bạn đã quá hạn trả sách</h2>
                                    <hr>
                                    <p>Sách: <strong>{a.ctm.MaSach}</strong></p>
                                    <p>Ngày mượn: <strong>{a.ctm.NgayMuon}</strong></p>
                                    <p>Hạn trả: <strong>{a.ctm.HanTra}</strong></p>
                                    <p>Bạn đã quá hạn trả: <strong>{(DateTime.Now.Date - a.ctm.HanTra.Date).Days} ngày</strong></p>
                                    <h4>Vui lòng đến thư viện liên hệ thủ thư để trả sách !!!</h4>");
                       }
                   }
               }
                );
            Console.WriteLine("Send mail Successfully!");   
        }
    }
}
