using FikretMungan.Data;
using Microsoft.AspNetCore.Mvc;

namespace FikretMungan.Controllers
{
    public class DocumentController : Controller
    {
        private readonly DatabaseContext _context;

        public DocumentController(DatabaseContext context)
        {
            _context = context;
        }
        [Route("belgelerimiz")]
        public IActionResult Index()
        {
            var model=_context.Documents.ToList();
            return View(model);
        }
    }
}
