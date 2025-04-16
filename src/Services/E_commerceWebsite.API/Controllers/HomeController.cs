using Microsoft.AspNetCore.Mvc;

namespace E_commerceWebsite.API.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
