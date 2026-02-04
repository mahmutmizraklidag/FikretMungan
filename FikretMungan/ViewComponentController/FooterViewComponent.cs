using Microsoft.AspNetCore.Mvc;

namespace FikretMungan.ViewComponentController
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
