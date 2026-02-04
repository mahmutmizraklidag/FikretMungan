using FikretMungan.Data;
using Microsoft.AspNetCore.Mvc;

namespace FikretMungan.Controllers
{
    public class ServiceController : Controller
    {
        private readonly DatabaseContext _context;

        public ServiceController(DatabaseContext context)
        {
            _context = context;
        }
        [Route("hizmetlerimiz")]
        public IActionResult Index()
        {
            var model=_context.Services.ToList();
            return View(model);
        }
        [Route("hizmetlerimiz/{slug}")]
        public IActionResult Detail(string slug)
        {
            var model=_context.Services.FirstOrDefault(x => x.Slug == slug);
            return View(model);
        }
    }
}
