using FikretMungan.Data;
using Microsoft.AspNetCore.Mvc;

namespace FikretMungan.Controllers
{
    public class AboutController : Controller
    {
        private readonly DatabaseContext _context;

        public AboutController(DatabaseContext context)
        {
            _context = context;
        }
        [Route("hakkimizda")]
        public IActionResult Index()
        {
            var model=_context.Abouts.ToList();
            return View(model);
        }
    }
}
