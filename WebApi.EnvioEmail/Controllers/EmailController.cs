using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApi.EnvioEmail.Data;
using WebApi.EnvioEmail.Models;

namespace WebApi.EnvioEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly DbContextEmail _context;

        public EmailController(DbContextEmail context)
        {
            _context = context;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail(int id)
        {
            var pessoa = await _context.Pessoa.FirstOrDefaultAsync(m => m.Id == id);
            var remetente = await _context.EmailRemetente.FirstOrDefaultAsync(m => m.Id == pessoa.Id);

            remetente.DestinatarioEmail = pessoa.Email;

            try
            {
                await SendEmailAsync(remetente);
                return Ok("Email enviado com sucesso.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SendEmailAsync(EmailRemetente remetente)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress(remetente.RemetenteEmail, remetente.NameEmpresa);
            message.To.Add(new MailAddress(remetente.DestinatarioEmail));
            message.Subject = remetente.Assunto;
            message.IsBodyHtml = false;
            message.Body = remetente.Corpo;
            smtp.Port = remetente.Port;
            smtp.Host = remetente.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(remetente.RemetenteEmail, remetente.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}