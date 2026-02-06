using FikretMungan.Data;
using FikretMungan.Entities;
using FikretMungan.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FikretMungan.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class DocumentsController : Controller
    {
        private readonly DatabaseContext _context;

        public DocumentsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: admin/References
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documents.ToListAsync());
        }



        // GET: admin/References/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/References/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Document document, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                if (Image is not null) document.Image = await FileHelper.FileLoaderAsync(Image);
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: admin/References/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.Documents.FindAsync(id);
            if (reference == null)
            {
                return NotFound();
            }
            return View(reference);
        }

        // POST: admin/References/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Document document, IFormFile? Image)
        {
            if (id != document.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(document);
            }
            var dbReference = await _context.Documents.FirstOrDefaultAsync(r => r.Id == id);
            if (dbReference == null)
            {
                return NotFound();
            }
            if (Image is not null)
            {
                if (!string.IsNullOrEmpty(dbReference.Image))
                {
                    FileHelper.DeleteFile(dbReference.Image);
                }
                dbReference.Image = await FileHelper.FileLoaderAsync(Image);
            }
            dbReference.Title = document.Title;
            dbReference.IsHome = document.IsHome;
            dbReference.OrderNo = document.OrderNo;

            _context.Update(dbReference);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Documents", new { area = "Admin" });
        }

        // GET: admin/References/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.Documents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // POST: admin/References/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                if (!string.IsNullOrEmpty(document.Image))
                {
                    FileHelper.DeleteFile(document.Image);
                }
                _context.Documents.Remove(document);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(int[] idList)
        {
            try
            {
                // 1. Gelen ID listesindeki tüm dökümanları veritabanından çekiyoruz.
                // (Tek tek sorgu atmak yerine toplu çekmek performansı artırır)
                var documents = await _context.Documents
                                              .Where(d => idList.Contains(d.Id))
                                              .ToListAsync();

                // 2. Gelen sıralı listeye göre döngü kuruyoruz
                for (int i = 0; i < idList.Length; i++)
                {
                    // Listeden o anki ID'ye sahip dökümanı buluyoruz
                    var doc = documents.FirstOrDefault(d => d.Id == idList[i]);

                    if (doc != null)
                    {
                        // Dizideki sırasına göre OrderNo'yu güncelliyoruz (+1 çünkü dizi 0'dan başlar)
                        doc.OrderNo = i + 1;
                    }
                }

                // 3. Değişiklikleri kaydediyoruz
                await _context.SaveChangesAsync();

                return Ok(); // Başarılı (200) döndür
            }
            catch (Exception)
            {
                return BadRequest(); // Hata oluştu
            }
        }
        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.Id == id);
        }
    }
}
