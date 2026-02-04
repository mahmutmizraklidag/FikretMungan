using FikretMungan.Data;
using Microsoft.AspNetCore.Mvc;

namespace FikretMungan.Controllers
{
    public class FaqsController : Controller
    {
        private readonly DatabaseContext _context;

        public FaqsController(DatabaseContext context)
        {
            _context = context;
        }
        [Route("sss")]
        public IActionResult Index()
        {
            var model = _context.Faqs.ToList();
            return View(model);
        }
    }
}
