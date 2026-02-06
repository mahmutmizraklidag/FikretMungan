using FikretMungan.Data;
using FikretMungan.Entities;
using FikretMungan.Models;
using FikretMungan.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FikretMungan.Controllers
{
    public class ContactController : Controller
    {
        private readonly DatabaseContext _context;

        public ContactController(DatabaseContext context)
        {
            _context = context;
        }
        [Route("iletisim")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactForm entity)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    _context.ContactForms.Add(entity);
                    int result = await _context.SaveChangesAsync();

                    if (result > 0)
                    {
                        var temp = MailTemplates.ContactFormTemplate(entity);
                        var confirmationTemp = MailTemplates.CustomerConfirmationTemplate(entity);
                        MailSender mailSender = new MailSender();
                        await mailSender.SendMailAsync(DataRequestModel.SiteSetting.Email, "İletişim Formu Talebi", temp, entity.Name);
                        await mailSender.SendMailAsync(entity.Email, "İletişim Formu Talebiniz Alındı", confirmationTemp, entity.Name);
                        return Json(new { success = true, message = "Mesajınız gönderildi." });
                    }
                }
                catch
                {
                    return Json(new { success = false, message = "Hata oluştu!" });
                }
            }
            return Json(new { success = false, message = "Form bilgileri hatalı!" });
        }
    }
}
