using Microsoft.AspNetCore.Mvc;

namespace AlphaAPI.Controllers
{
    public class MVC : Controller
    {
        [Route("")]
        public IActionResult Index()
        {

            return View();
        }
        [Route("AlphaHR")]
        public IActionResult AlphaHR()
        {
            return View();
        }
        [Route("AlphaWF")]
        public IActionResult AlphaWF()
        {
            return View();
        }
        [Route("AlphaProd")]
        public IActionResult AlphaProd()
        {
            return View();
        }
        [Route("VisitPaidInvoices")]
        public IActionResult VisitPaidInvoices()
        {
            return View();
        }
    }
}
