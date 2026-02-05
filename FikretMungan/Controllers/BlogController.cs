using FikretMungan.Data;
using Microsoft.AspNetCore.Mvc;

namespace FikretMungan.Controllers
{
    public class BlogController : Controller
    {
        private readonly DatabaseContext _context;

        public BlogController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("blog")]
        public IActionResult Index()
        {
            var model= _context.Blogs.OrderByDescending(x => x.CreatedAt).ToList();
            return View(model);
        }
        [Route("blog/{slug}")]
        public IActionResult Detail(string slug)
        {
            var blog= _context.Blogs.FirstOrDefault(b => b.Slug==slug);
          
            return View(blog);
        }
    }
}
